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
  //  [Authorize]
    public class UserController : ControllerBase
    {
        public readonly IUser _iUser;

        public UserController(IUser iUser)
        {
            _iUser = iUser;
        }

        [HttpPost("GetAllUser")]
        public async Task<CommonResponse> GetAllUser(GetAllUserReqViewModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.GetAllUser(request.Adapt<GetAllUserUserReqDTO>());
                GetAllUserUserResDTO resDTO = response.Data;
                response.Data = resDTO.Adapt<GetAllUserUserResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("GetAllTutor")]
        public async Task<CommonResponse> GetAllTutor(GetAllTutorReqViewModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.GetAllTutor(request.Adapt<GetAllTutorReqDTO>());
                GetAllTutorResDTO resDTO = response.Data;
                response.Data = resDTO.Adapt<GetAllTutorResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("GetAllStudent")]
        public async Task<CommonResponse> GetAllStudent(GetAllStudentReqViewModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.GetAllStudent(request.Adapt<GetAllStudentReqDTO>());
                GetAllStudentResDTO resDTO = response.Data;
                response.Data = resDTO.Adapt<GetAllStudentResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddEditUser")]
        public async Task<CommonResponse> AddEditUser(AddEditUserReqViewModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.AddEditUser(request.Adapt<AddEditUserReqDTO>());
                AddEditUserResDTO resDTO = response.Data;
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
