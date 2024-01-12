using DTO.ReqDTO;
using Helper.CommonHelpers;
using Helper.CommonModels;

namespace BussinessLayer
{
    public class AuthBLL
    {
        private readonly AuthHelper _authHelper;
        private readonly CommonRepo _commonRepo;

        public AuthBLL(AuthHelper authHelper, CommonRepo commonRepo)
        {
            _authHelper = authHelper;
            _commonRepo = commonRepo;
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
