using DTO.ReqDTO;
using DTO.ResDTO;
using Helper.CommonModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using WebAPI.ViewModel.ReqViewModel;
using WebAPI.ViewModel.ResViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _iCouse;
        public CourseController(ICourse iCourse)
        {
            _iCouse = iCourse;
        }

        [HttpPost("AddCourse")]
        public async Task<CommonResponse> AddCourse(AddCourseReqViewModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iCouse.AddCourse(request.Adapt<AddCourseReqDTO>());
                AddCourseResDTO resDTO = response.Data;
                response.Data = resDTO.Adapt<AddCourseResViewModel>();
            }
            catch { throw; }
            return response;
        }
    }
}
