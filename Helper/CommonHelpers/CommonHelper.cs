using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Helper.CommonHelpers
{
    public class CommonHelper
    {
        public const string DATE_FORMAT = "dd/MM/yyyy";
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommonHelper(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        #region DateTime

        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        public string GetDateInString(DateTime date)
        {
            return date.ToString(DATE_FORMAT).Replace("-", "/");
        }

        public DateTime GetDateFromString(string date)
        {
            return DateTime.ParseExact(date, DATE_FORMAT, CultureInfo.InvariantCulture);
        }

        public string GetAge(DateTime dateTime)
        {
            DateTime birthDate = Convert.ToDateTime(dateTime);
            int age = (int)Math.Floor((GetCurrentDateTime() - birthDate).TotalDays / 365.25D);
            return age.ToString();
        }

        #endregion


        #region Random Keyword

        public string GenerateRandomPassword(int length = 8)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        public string GenerateRandomDigit(int length = 6)
        {
            string validChars = "1234567890";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
        #endregion


        #region Authentication
        public int GetLoggedInUserIdAsync()
        {
            ClaimsPrincipal claimsPrincipal = GetLoggedInUserDataAsync();

            var UserId = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault();

            return Convert.ToInt32(UserId);
        }

        public int GetLoggedInUsersRegionIdAsync()
        {
            ClaimsPrincipal claimsPrincipal = GetLoggedInUserDataAsync();

            var RegionId = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault();

            return Convert.ToInt32(RegionId);
        }

        public string GetLoggedInUsersRoleAsync()
        {
            ClaimsPrincipal claimsPrincipal = GetLoggedInUserDataAsync();

            var roleName = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).FirstOrDefault();

            return Convert.ToString(roleName);
        }

        public ClaimsPrincipal GetLoggedInUserDataAsync()
        {
            string accessToken = Convert.ToString(_httpContextAccessor.HttpContext.Request.Headers["Authorization"]) ?? "";

            if (string.IsNullOrEmpty(accessToken)) { return new ClaimsPrincipal(); }
            accessToken = accessToken.Replace("Bearer ", "").Trim();

            SecurityToken validatedToken;
            return GetUserIdFromToken(accessToken, out validatedToken);
        }

        private ClaimsPrincipal GetUserIdFromToken(string token, out SecurityToken validatedToken)
        {
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            var tokenHandler = new JwtSecurityTokenHandler();
            var secreatekey = Convert.ToString(_configuration["JsonWebTokenKeys:IssuerSigningKey"]);
            var ValidIssuer = Convert.ToString(_configuration["JsonWebTokenKeys:ValidIssuer"]);
            var ValidAudience = Convert.ToString(_configuration["JsonWebTokenKeys:ValidAudience"]);
            var RefreshTokenExpiryDays = Convert.ToInt32(Convert.ToString(_configuration["JsonWebTokenKeys:RefreshTokenexpiryDays"]));

            claimsPrincipal = tokenHandler.ValidateToken(token,
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = ValidIssuer,
                ValidateAudience = true,
                ValidAudience = ValidAudience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreatekey)),
                ClockSkew = TimeSpan.FromDays(RefreshTokenExpiryDays),
                ValidateLifetime = true
            }, out validatedToken);

            return claimsPrincipal;
        }
        #endregion
    }
}
