using DTO.ReqDTO;
using DTO.ResDTO;
using Helper.CommonHelpers;
using Helper.CommonModels;

namespace BussinessLayer
{
    public class AuthBLL
    {
        private readonly AuthHelper _authHelper;

        public AuthBLL(AuthHelper authHelper )
        {
            _authHelper = authHelper;
        }
        public async Task<CommonResponse> Login(LoginReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _authHelper.Login(request);
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> CreateNewToken(CreateTokenReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _authHelper.CreateNewToken(request);
            }
            catch { throw; }
            return response;
        }
    }
}
