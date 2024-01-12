using BussinessLayer;
using DTO.ReqDTO;
using Helper.CommonModels;

namespace ServiceLayer
{
    public class UserImpl : IUser
    {
        public readonly UserBLL _userBLL;

        public UserImpl(UserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        public async Task<CommonResponse> GetAllUser(GetAllUserUserReqDTO request) => await _userBLL.GetAllUser(request);
        public async Task<CommonResponse> GetAllTutor(GetAllTutorReqDTO request) => await _userBLL.GetAllTutor(request);
        public async Task<CommonResponse> GetAllStudent(GetAllStudentReqDTO request) => await _userBLL.GetAllStudent(request);
        public async Task<CommonResponse> AddEditUser(AddEditUserReqDTO request) => await _userBLL.AddEditUser(request);
        public async Task<CommonResponse> UpdateStudent(UpdateStudentReqDTO request) => await _userBLL.UpdateStudent(request);
        public async Task<CommonResponse> UpdateTutor(UpdateTutorReqDTO request) => await _userBLL.UpdateTutor(request);

    }

    public interface IUser
    {
        public Task<CommonResponse> GetAllUser(GetAllUserUserReqDTO request);
        public Task<CommonResponse> GetAllTutor(GetAllTutorReqDTO request);
        public Task<CommonResponse> GetAllStudent(GetAllStudentReqDTO request);
        public Task<CommonResponse> AddEditUser(AddEditUserReqDTO request);
        public Task<CommonResponse> UpdateStudent(UpdateStudentReqDTO request);
        public Task<CommonResponse> UpdateTutor(UpdateTutorReqDTO request);

    }
}
