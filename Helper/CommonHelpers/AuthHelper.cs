using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Helper.CommonModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Helper.CommonHelpers
{
    public class AuthHelper
    {
        private readonly DBContext _dbContext;
        private readonly CommonRepo _commonRepo;
        private readonly IConfiguration _configuration;
        private readonly CommonHelper _commonHelper;

        public AuthHelper(DBContext dbContext, CommonRepo commonRepo, IConfiguration configuration, CommonHelper commonHelper)
        {
            _dbContext = dbContext;
            _commonRepo = commonRepo;
            _configuration = configuration;
            _commonHelper = commonHelper;
        }

        public async Task<CommonResponse> Login(LoginReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                LoginResDTO res = new LoginResDTO();
                TokenMst token = new TokenMst();
                DateTime currentDateTime = _commonHelper.GetCurrentDateTime();

                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => (x.Email == request.EmailOrPhoneNo.Trim() || x.PhoneNo == request.EmailOrPhoneNo.Trim()) && x.Password == request.Password);
                if (userDetail != null)
                {
                    var tokenString = await GenerateToken(userDetail.Id.ToString());
                    string refreshtokenstring = await GenerateRefreshToken();

                    var tokenDetail = await _commonRepo.TokenMstList().FirstOrDefaultAsync(x => x.UserId == userDetail.Id);

                    if (tokenDetail != null)
                    {
                        tokenDetail.Token = tokenString;
                        tokenDetail.TokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:TokenExpiryMin"]));
                        tokenDetail.RefreshToken = refreshtokenstring;
                        tokenDetail.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:RefreshTokenexpiryMin"]));
                        tokenDetail.UpdatedDate = currentDateTime;
                        _dbContext.Entry(tokenDetail).State = EntityState.Modified;
                        _dbContext.SaveChanges();

                        res.TokenExpiryTime = tokenDetail.TokenExpiryTime;
                    }
                    else
                    {
                        token.Token = tokenString;
                        token.TokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:TokenExpiryMin"]));
                        token.RefreshToken = refreshtokenstring;
                        token.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:RefreshTokenexpiryMin"]));
                        token.CreatedDate = currentDateTime;
                        token.UpdatedDate = currentDateTime;
                        token.UserId = userDetail.Id;
                        _dbContext.TokenMsts.Add(token);
                        _dbContext.SaveChanges();

                        res.TokenExpiryTime = token.TokenExpiryTime;
                    }

                    res.Token = tokenString;
                    res.RefreshToken = refreshtokenstring;

                    if (userDetail.Email == request.EmailOrPhoneNo)
                    {
                        res.EmailOrPhoneNo = userDetail.Email;
                    }
                    else
                    {
                        res.EmailOrPhoneNo = userDetail.PhoneNo;
                    }
                    response.Data = res;
                    response.Message = "login successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Email or Password is not correct";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> CreateNewToken(CreateTokenReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                CreateTokenResDTO res = new CreateTokenResDTO();
                DateTime currentDateTime = _commonHelper.GetCurrentDateTime();

                var tokenDetail = await _commonRepo.TokenMstList().FirstOrDefaultAsync(x => x.Token == request.Token.Trim() && x.RefreshToken == request.RefreshToken.Trim());
                if (tokenDetail != null)
                {
                    var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.Id == tokenDetail.UserId);
                    if (userDetail != null)
                    {
                        string Token = request.Token.Trim();
                        string refreshToken = request.RefreshToken.Trim();
                        var tokenHandler = new JwtSecurityTokenHandler();
                        SecurityToken securityToken;
                        var principal = tokenHandler.ValidateToken(Token, new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = false,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebTokenKeys:IssuerSigningKey"]))
                        }, out securityToken);

                        var jwtSecurityToken = securityToken as JwtSecurityToken;
                        var userId = principal.Identity.Name;

                        if (userId == userDetail.Id.ToString())
                        {
                            //if refresh token expired
                            if (tokenDetail.RefreshToken != refreshToken || tokenDetail.RefreshTokenExpiryTime <= DateTime.Now)
                            {
                                response.Message = "Refresh token is expired";
                                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                                return response;
                            }
                            //if token is not expired
                            else if (tokenDetail.Token != Token || tokenDetail.TokenExpiryTime >= DateTime.Now)
                            {
                                response.Message = "Token is not expired";
                                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                                return response;
                            }
                            else
                            {
                                //if token expired but refreh token not expired
                                var tokenString = await GenerateToken(userDetail.Id.ToString());
                                string refreshtokenstring = await GenerateRefreshToken();
                                tokenDetail.Token = tokenString;
                                tokenDetail.TokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:TokenExpiryMin"]));
                                tokenDetail.RefreshToken = refreshtokenstring;
                                tokenDetail.UpdatedDate = currentDateTime;
                                _dbContext.Entry(tokenDetail).State = EntityState.Modified;
                                _dbContext.SaveChanges();

                                res.Token = tokenString;
                                res.RefreshToken = refreshtokenstring;
                                res.RefreshTokenExpiryTime = tokenDetail.RefreshTokenExpiryTime;

                                response.Data = res;
                                response.Message = "New token generated successfully";
                                response.Status = true;
                                response.StatusCode = System.Net.HttpStatusCode.OK;
                            }
                        }
                    }
                    else
                    {
                        response.Message = "User is not corrct";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Message = "Token is not correct";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<string> GenerateToken(string UserId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebTokenKeys:IssuerSigningKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                          new Claim(ClaimTypes.Name,UserId),
            };
            var token = new JwtSecurityToken(_configuration["JsonWebTokenKeys:ValidIssuer"],
                _configuration["JsonWebTokenKeys:ValidAudience"],
                claims,

                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JsonWebTokenKeys:TokenExpiryMin"])),
                signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        public async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            string refreshtokenstring = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshtokenstring = Convert.ToBase64String(randomNumber);
            }
            return refreshtokenstring;
        }
    }
}
