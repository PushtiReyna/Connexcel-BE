using BussinessLayer;
using DTO.ReqDTO;
using Helper.CommonModels;

namespace ServiceLayer
{
    public class AuthImpl : IAuth
    {
        private readonly AuthBLL _authBLL;

        public AuthImpl(AuthBLL authBLL)
        {
            _authBLL = authBLL;
        }

        public async Task<CommonResponse> Login(LoginReqDTO request) => await _authBLL.Login(request);
        public async Task<CommonResponse> CreateNewToken(CreateTokenReqDTO request) => await _authBLL.CreateNewToken(request);
    }

    public interface IAuth
    {
        public Task<CommonResponse> Login(LoginReqDTO request);
        public Task<CommonResponse> CreateNewToken(CreateTokenReqDTO request);
    }
}
