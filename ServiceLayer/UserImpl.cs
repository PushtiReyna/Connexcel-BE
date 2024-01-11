using BussinessLayer;
using DTO.ReqDTO;
using Helper.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserImpl : IUser
    {
        public readonly UserBLL _userBLL;

        public UserImpl(UserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        public async Task<CommonResponse> GetUser(GetUserUserReqDTO request) => await _userBLL.GetUser(request);
        public async Task<CommonResponse> AddUser(AddUserReqDTO request) => await _userBLL.AddUser(request);
        public async Task<CommonResponse> UpdateStudent(UpdateStudentReqDTO request) => await _userBLL.UpdateStudent(request);
        public async Task<CommonResponse> UpdateTutor(UpdateTutorReqDTO request) => await _userBLL.UpdateTutor(request);

    }

    public interface IUser
    {
        public Task<CommonResponse> GetUser(GetUserUserReqDTO request);
        public Task<CommonResponse> AddUser(AddUserReqDTO request);
        public Task<CommonResponse> UpdateStudent(UpdateStudentReqDTO request);
        public Task<CommonResponse> UpdateTutor(UpdateTutorReqDTO request);

    }
}
