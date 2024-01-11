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
    public class UserController : ControllerBase
    {
        public readonly IUser _iUser;

        public UserController(IUser iUser)
        {
            _iUser = iUser;
        }

        [HttpPost("GetUser")]
        public async Task<CommonResponse> GetUser(GetUserReqViewModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.GetUser(request.Adapt<GetUserUserReqDTO>());
                GetUserUserResDTO resDTO = response.Data;
                response.Data = resDTO.Adapt<GetUserUserResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddUser")]
        public async Task<CommonResponse> AddUser(AddUserReqViewModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.AddUser(request.Adapt<AddUserReqDTO>());
                AddUserResDTO resDTO = response.Data;
                response.Data = resDTO.Adapt<AddUserResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("UpdateStudent")]
        public async Task<CommonResponse> UpdateStudent(UpdateStudentReqViewModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.UpdateStudent(request.Adapt<UpdateStudentReqDTO>());
                UpdateStudentResDTO resDTO = response.Data;
                response.Data = resDTO.Adapt<UpdateStudentResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("UpdateTutor")]
        public async Task<CommonResponse> UpdateTutor(UpdateTutorReqViewModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.UpdateTutor(request.Adapt<UpdateTutorReqDTO>());
                UpdateTutorResDTO resDTO = response.Data;
                response.Data = resDTO.Adapt<UpdateTutorResViewModel>();
            }
            catch { throw; }
            return response;
        }

    }
}
