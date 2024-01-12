using BussinessLayer;
using Helper.CommonModels;

namespace ServiceLayer
{
    public class CommonImpl : ICommon
    {
        private readonly CommonBLL _commonBLL;

        public CommonImpl(CommonBLL commonBLL)
        {
            _commonBLL = commonBLL;
        }

        public async Task<CommonResponse> GetUserType() => await _commonBLL.GetUserType();
        public async Task<CommonResponse> GetTimeZone() => await _commonBLL.GetTimeZone();
        public async Task<CommonResponse> GetLocalization() => await _commonBLL.GetLocalization();
        public async Task<CommonResponse> GetPlatformPreference() => await _commonBLL.GetPlatformPreference();
        public async Task<CommonResponse> GetCourseType() => await _commonBLL.GetCourseType();
        public async Task<CommonResponse> GetCourseStatus() => await _commonBLL.GetCourseStatus();
    }

    public interface ICommon
    {
        public Task<CommonResponse> GetUserType();
        public Task<CommonResponse> GetTimeZone();
        public Task<CommonResponse> GetLocalization();
        public Task<CommonResponse> GetPlatformPreference();
        public Task<CommonResponse> GetCourseType();
        public Task<CommonResponse> GetCourseStatus();
    }
}
