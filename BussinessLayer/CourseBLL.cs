using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Helper.CommonHelpers;
using Helper.CommonModels;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer
{
    public class CourseBLL
    {
        public readonly CommonRepo _commonRepo;
        public readonly DBContext _dbContext;
        private readonly CommonHelper _commonHelper;

        public CourseBLL(CommonRepo commonRepo, DBContext dbContext, CommonHelper commonHelper)
        {
            _commonRepo = commonRepo;
            _dbContext = dbContext;
            _commonHelper = commonHelper;
        }

        public async Task<CommonResponse> AddCourse(AddCourseReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AddCourseResDTO resDTO = new AddCourseResDTO();
                CourseMst course = new CourseMst();
                int loggedInUserId = _commonHelper.GetLoggedInUserIdAsync();
                DateTime currentDateTime = _commonHelper.GetCurrentDateTime();

                bool isExist = await _commonRepo.CourseMstlList().AnyAsync(x => x.CourseName == request.CourseName && x.CourseType == request.CourseType);

                if (isExist == false)
                {
                    course.IsActive = true;
                    course.IsDelete = false;
                    course.CreatedBy = loggedInUserId;
                    course.UpdatedBy = loggedInUserId;
                    course.CreatedDate = currentDateTime;
                    course.UpdatedDate = currentDateTime;
                    course.CourseType = request.CourseType;
                    course.NoofLessons = request.NoofLessons;
                    course.StartDate = request.StartDate;
                    course.EndDate = request.EndDate;   
                    course.StudentDefaultRate = request.StudentDefaultRate;
                    course.CourseName = request.CourseName;
                    course.Frequency = request.Frequency;
                    course.Subject = request.Subject;
                    course.Tutors = request.Tutors;

                    await _dbContext.CourseMsts.AddAsync(course);
                    await _dbContext.SaveChangesAsync();

                    resDTO.Id = course.Id;
                    response.Data = resDTO;
                    response.Status = true;
                    response.Message = "Course Added Successfully!";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Course Name already exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
    }
}
