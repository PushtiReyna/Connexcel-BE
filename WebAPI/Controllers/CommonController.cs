using Helper.CommonModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommonController : ControllerBase
    {
        private readonly ICommon _iCommon;

        public CommonController(ICommon iCommon)
        {
           _iCommon = iCommon;
        }

        [HttpGet("GetUserType")]
        public async Task<CommonResponse> GetUserType()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iCommon.GetUserType();
            }
            catch { throw; }
            return response;
        }

        [HttpGet("GetTimeZone")]
        public async Task<CommonResponse> GetTimeZone()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iCommon.GetTimeZone();
            }
            catch { throw; }
            return response;
        }

        [HttpGet("GetLocalization")]
        public async Task<CommonResponse> GetLocalization()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iCommon.GetLocalization();
            }
            catch { throw; }
            return response;
        }

        [HttpGet("GetPlatformPreference")]
        public async Task<CommonResponse> GetPlatformPreference()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iCommon.GetPlatformPreference();
            }
            catch { throw; }
            return response;
        }
    }
}
