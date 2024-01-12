using Helper.CommonHelpers;
using Helper.CommonModels;
using Microsoft.EntityFrameworkCore;
using static Helper.CommonModels.CommonEnums;

namespace BussinessLayer
{
    public class TutorBLL
    {
        private readonly CommonRepo _commonRepo;

        public TutorBLL(CommonRepo commonRepo)
        {
            _commonRepo = commonRepo; ;
        }
        public async Task<CommonResponse> GetAllTutor()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var lstUser = await (from userDetail in _commonRepo.UserMstList().Where(x => x.UserType == UserType.Tutor.ToString())
                                     select new
                                     {
                                         userDetail.Id,
                                         FullName = userDetail.FirstName + " " + userDetail.LastName,
                                     }).ToListAsync();
                if (lstUser.Count > 0)
                {
                    response.Data = lstUser;
                    response.Status = true;
                    response.Message = "Data found successfully!";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Data not found!";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }
    }
}
