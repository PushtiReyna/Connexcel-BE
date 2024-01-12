using Helper.CommonModels;
using static Helper.CommonModels.CommonEnums;

namespace BussinessLayer
{
    public class CommonBLL
    {
        public async Task<CommonResponse> GetUserType()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var userTypeList = ((UserType[])Enum.GetValues(typeof(UserType))).Select(x => new { Text = x.ToString() }).ToList();

                if (userTypeList.Count > 0)
                {
                    response.Data = userTypeList;
                    response.Status = true;
                    response.Message = "Data found Suceessfull!";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Data not found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetTimeZone()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var timeZoneList = ((CommonEnums.TimeZone[])Enum.GetValues(typeof(CommonEnums.TimeZone))).Select(x => new { Text = x.ToString() }).ToList();

                if (timeZoneList.Count > 0)
                {
                    response.Data = timeZoneList;
                    response.Status = true;
                    response.Message = "Data found Suceessfull!";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Data not found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetLocalization()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var localizationList = ((Localization[]) Enum.GetValues(typeof(Localization))).Select(x => new { Text = x.ToString() }).ToList();

                if (localizationList.Count > 0)
                {
                    response.Data = localizationList;
                    response.Status = true;
                    response.Message = "Data found Suceessfull!";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Data not found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetPlatformPreference()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var platformPreferenceList = ((PlatformPreference[])Enum.GetValues(typeof(PlatformPreference))).Select(x => new { Text = x.ToString() }).ToList();

                if (platformPreferenceList.Count > 0)
                {
                    response.Data = platformPreferenceList;
                    response.Status = true;
                    response.Message = "Data found Suceessfull!";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Data not found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetCourseType()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var courseTypeList = ((CourseType[])Enum.GetValues(typeof(CourseType))).Select(x => new { Text = x.ToString() }).ToList();

                if (courseTypeList.Count > 0)
                {
                    response.Data = courseTypeList;
                    response.Status = true;
                    response.Message = "Data found Suceessfull!";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Data not found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetCourseStatus()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var courseStatusList = ((CourseStatus[])Enum.GetValues(typeof(CourseStatus))).Select(x => new { Text = x.ToString() }).ToList();

                if (courseStatusList.Count > 0)
                {
                    response.Data = courseStatusList;
                    response.Status = true;
                    response.Message = "Data found Suceessfull!";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Data not found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }
    }
}
