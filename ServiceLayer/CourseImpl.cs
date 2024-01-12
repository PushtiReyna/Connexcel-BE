using BussinessLayer;
using DTO.ReqDTO;
using Helper.CommonModels;

namespace ServiceLayer
{
    public class CourseImpl : ICourse
    {
        private readonly CourseBLL _courseBLL;

        public CourseImpl(CourseBLL courseBLL)
        {
            _courseBLL = courseBLL;
        }

        public async Task<CommonResponse> AddCourse(AddCourseReqDTO request) => await _courseBLL.AddCourse(request);
    }
    public interface ICourse
    {
        public Task<CommonResponse> AddCourse(AddCourseReqDTO request);
    }
}
