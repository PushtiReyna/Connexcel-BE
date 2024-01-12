using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Helper.CommonHelpers;
using Helper.CommonModels;
using Microsoft.EntityFrameworkCore;
using static Helper.CommonModels.CommonEnums;

namespace BussinessLayer
{
    public class UserBLL
    {
        public readonly CommonRepo _commonRepo;
        public readonly DBContext _dbContext;
        private readonly CommonHelper _commonHelper;

        public UserBLL(CommonRepo commonRepo, DBContext dbContext, CommonHelper commonHelper)
        {
            _commonRepo = commonRepo;
            _dbContext = dbContext;
            _commonHelper = commonHelper;
        }

        public async Task<CommonResponse> GetAllUser(GetAllUserUserReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                GetAllUserUserResDTO resDTO = new GetAllUserUserResDTO();
                var lstUser = await (from userDetail in _commonRepo.UserMstList()
                                     select new
                                     {
                                         userDetail.Id,
                                         DateRegistred = userDetail.CreatedDate,
                                         userDetail.UserType,
                                         FullName = userDetail.FirstName + " " + userDetail.LastName,
                                         userDetail.Email,
                                         // NoOfCourses = userDetail.NumberOfCourses,
                                         userDetail.LastLogin,
                                         userDetail.IsActive,
                                     }).ToListAsync();

                if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Trim()))
                {
                    lstUser = lstUser.Where(x => x.FullName.ToLower().Contains(request.Search.ToLower())).ToList();
                }

                if (request.IsTutor != null)
                {
                    lstUser = lstUser.Where(x => x.UserType == (Convert.ToBoolean(request.IsTutor) ? "Tutor" : "Student")).ToList();
                }

                if (request.OrderBy == true)
                {
                    lstUser = lstUser.OrderBy(x => x.Id)
                                            .Skip((request.Page - 1) * request.ItemsPerPage)
                                            .Take(request.ItemsPerPage).ToList();
                }
                else
                {
                    lstUser = lstUser.OrderByDescending(x => x.Id)
                                           .Skip((request.Page - 1) * request.ItemsPerPage)
                                            .Take(request.ItemsPerPage).ToList();
                }
                resDTO.TotalCount = lstUser.Count;
                resDTO.UserLists = lstUser;
                if (lstUser.Count > 0)
                {
                    response.Data = resDTO;
                    response.Message = "Data found successfully!";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Data not found!";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetAllTutor(GetAllTutorReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                GetAllTutorResDTO resDTO = new GetAllTutorResDTO();
                var lstUser = await (from userDetail in _commonRepo.UserMstList().Where(x => x.UserType == UserType.Tutor.ToString())
                                     select new
                                     {
                                         userDetail.Id,
                                         DateRegistred = userDetail.CreatedDate.Date,
                                         //AssociatedCourses
                                         //Student
                                         //CourseStatus
                                         userDetail.LastLogin,
                                     }).ToListAsync();

                if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Trim()))
                {
                    lstUser = lstUser.Where(x => x.Id.ToString() == request.Search).ToList();
                }

                if (request.OrderBy == true)
                {
                    lstUser = lstUser.OrderBy(x => x.Id)
                                            .Skip((request.Page - 1) * request.ItemsPerPage)
                                            .Take(request.ItemsPerPage).ToList();
                }
                else
                {
                    lstUser = lstUser.OrderByDescending(x => x.Id)
                                           .Skip((request.Page - 1) * request.ItemsPerPage)
                                            .Take(request.ItemsPerPage).ToList();
                }
                resDTO.TotalCount = lstUser.Count;
                resDTO.UserLists = lstUser;
                if (lstUser.Count > 0)
                {
                    response.Data = resDTO;
                    response.Message = "Data found successfully!";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Data not found!";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetAllStudent(GetAllStudentReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                GetAllStudentResDTO resDTO = new GetAllStudentResDTO();
                var lstUser = await (from userDetail in _commonRepo.UserMstList().Where(x => x.UserType == UserType.Student.ToString())
                                     select new
                                     {
                                         userDetail.Id,
                                         DateRegistred = userDetail.CreatedDate.Date,
                                         //AssociatedCourses
                                         //Tutor
                                         userDetail.LastLogin,
                                     }).ToListAsync();

                if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Trim()))
                {
                    lstUser = lstUser.Where(x => x.Id.ToString() == request.Search).ToList();
                }

                if (request.OrderBy == true)
                {
                    lstUser = lstUser.OrderBy(x => x.Id)
                                            .Skip((request.Page - 1) * request.ItemsPerPage)
                                            .Take(request.ItemsPerPage).ToList();
                }
                else
                {
                    lstUser = lstUser.OrderByDescending(x => x.Id)
                                           .Skip((request.Page - 1) * request.ItemsPerPage)
                                            .Take(request.ItemsPerPage).ToList();
                }
                resDTO.TotalCount = lstUser.Count;
                resDTO.UserLists = lstUser;
                if (lstUser.Count > 0)
                {
                    response.Data = resDTO;
                    response.Message = "Data found successfully!";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Data not found!";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddEditUser(AddEditUserReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UserMst user = new UserMst();
                AddEditUserResDTO resDTO = new AddEditUserResDTO();

                int loggedInUserId = _commonHelper.GetLoggedInUserIdAsync();
                DateTime currentDateTime = _commonHelper.GetCurrentDateTime();
                string Password = _commonHelper.GenerateRandomPassword();

                if (request.Id != 0)
                {
                    var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (userDetail != null)
                    {
                        if (_commonRepo.UserMstList().FirstOrDefault(x => x.Email.Trim() == request.Email.Trim() && x.Id != request.Id) != null)
                        {
                            response.Status = false;
                            response.Message = "Email already exists!";
                            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        }
                        else if (_commonRepo.UserMstList().FirstOrDefault(x => x.PhoneNo.Trim() == request.PhoneNo.Trim() && x.Id != request.Id) != null)
                        {
                            response.Status = false;
                            response.Message = "Phone No. already exists!";
                            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        }
                        else
                        {
                            var tokenDetail = await _commonRepo.TokenMstList().FirstOrDefaultAsync(x => x.UserId == request.Id);

                            userDetail.UpdatedBy = loggedInUserId;
                            userDetail.UpdatedDate = currentDateTime;
                            userDetail.UserType = request.UserType;
                            userDetail.FirstName = request.FirstName;
                            userDetail.LastName = request.LastName;
                            userDetail.PhoneNo = request.PhoneNo;
                            userDetail.Email = request.Email;
                            userDetail.DefaultRate = request.DefaultRate;
                            userDetail.TimeZone = request.TimeZone;
                            userDetail.Localization = request.Localization;
                            userDetail.GuardianName = request.GuardianName;
                            userDetail.GuardianPhone = request.GuardianPhone;
                            if (tokenDetail != null)
                            {
                                userDetail.LastLogin = tokenDetail.UpdatedDate.Date;
                            }

                            _dbContext.Entry(userDetail).State = EntityState.Modified;
                            await _dbContext.SaveChangesAsync();

                            resDTO.Id = userDetail.Id;
                            response.Data = resDTO;
                            response.Status = true;
                            response.Message = "User Updated Successfully!";
                            response.StatusCode = System.Net.HttpStatusCode.OK;
                        }
                    }
                    else
                    {
                        response.Message = "Id is invalid!";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    bool isExist = await _commonRepo.UserMstList().AnyAsync(x => x.Email == request.Email || x.PhoneNo == request.PhoneNo);

                    if (isExist == false)
                    {
                        user.IsActive = true;
                        user.IsDelete = false;
                        user.CreatedBy = loggedInUserId;
                        user.UpdatedBy = loggedInUserId;
                        user.CreatedDate = currentDateTime;
                        user.UpdatedDate = currentDateTime;
                        user.UserType = request.UserType;
                        user.FirstName = request.FirstName;
                        user.LastName = request.LastName;
                        user.PhoneNo = request.PhoneNo;
                        user.Email = request.Email;
                        user.DefaultRate = request.DefaultRate;
                        user.TimeZone = request.TimeZone;
                        user.Localization = request.Localization;
                        user.GuardianName = request.GuardianName;
                        user.GuardianPhone = request.GuardianPhone;
                        user.Password = Password;

                        await _dbContext.UserMsts.AddAsync(user);
                        await _dbContext.SaveChangesAsync();

                        resDTO.Id = user.Id;
                        response.Data = resDTO;
                        response.Status = true;
                        response.Message = "User Added Successfully!";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Message = "Email or Phone No. already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> UpdateStudent(UpdateStudentReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateStudentResDTO resDTO = new UpdateStudentResDTO();
                int loggedInUserId = _commonHelper.GetLoggedInUserIdAsync();
                DateTime currentDateTime = _commonHelper.GetCurrentDateTime();

                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.Id == request.Id);
                if (userDetail != null)
                {
                    if (_commonRepo.UserMstList().FirstOrDefault(x => x.Email.Trim() == request.Email.Trim() && x.Id != request.Id) != null)
                    {
                        response.Status = false;
                        response.Message = "Email already exists!";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                    else if (_commonRepo.UserMstList().FirstOrDefault(x => x.PhoneNo.Trim() == request.PhoneNo.Trim() && x.Id != request.Id) != null)
                    {
                        response.Status = false;
                        response.Message = "Phone No. already exists!";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        var tokenDetail = await _commonRepo.TokenMstList().FirstOrDefaultAsync(x => x.UserId == request.Id);

                        userDetail.UpdatedBy = loggedInUserId;
                        userDetail.UpdatedDate = currentDateTime;
                        userDetail.FirstName = request.FirstName;
                        userDetail.LastName = request.LastName;
                        userDetail.PhoneNo = request.PhoneNo;
                        userDetail.TimeZone = request.TimeZone;
                        userDetail.Email = request.Email;
                        userDetail.SchoolYearGroup = request.SchoolYearGroup;
                        userDetail.DateofBirth = request.DateofBirth;
                        userDetail.School = request.School;
                        userDetail.UseableHours = request.UseableHours;
                        userDetail.HourlyRate = request.HourlyRate;
                        if (tokenDetail != null)
                        {
                            userDetail.LastLogin = tokenDetail.UpdatedDate.Date;
                        }

                        _dbContext.Entry(userDetail).State = EntityState.Modified;
                        await _dbContext.SaveChangesAsync();

                        resDTO.Id = userDetail.Id;
                        response.Data = resDTO;
                        response.Status = true;
                        response.Message = "User Updated Successfully!";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {
                    response.Message = "Id  is invalid!";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> UpdateTutor(UpdateTutorReqDTO request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateTutorResDTO resDTO = new UpdateTutorResDTO();
                List<TutorOfferingDetail> lstTutorOfferingDetail = new List<TutorOfferingDetail>();

                int loggedInUserId = _commonHelper.GetLoggedInUserIdAsync();
                DateTime currentDateTime = _commonHelper.GetCurrentDateTime();

                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.Id == request.Id);
                if (userDetail != null)
                {
                    if (_commonRepo.UserMstList().FirstOrDefault(x => x.PhoneNo.Trim() == request.PhoneNo.Trim() && x.Id != request.Id) != null)
                    {
                        response.Status = false;
                        response.Message = "Phone No. already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        foreach (var item in request.lstTutorOfferingDetails)
                        {
                            if (_commonRepo.TutorOfferingDetailList().FirstOrDefault(x => x.Subject == item.Subject && x.TutorId == request.Id) != null)
                            {
                                response.Status = false;
                                response.Message = "Subject already exists!";
                                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                                return response;
                            }
                            else
                            {
                                TutorOfferingDetail tutorOfferingDetail = new TutorOfferingDetail();
                                tutorOfferingDetail.TutorId = request.Id;
                                tutorOfferingDetail.IsActive = true;
                                tutorOfferingDetail.IsDelete = false;
                                tutorOfferingDetail.CreatedBy = loggedInUserId;
                                tutorOfferingDetail.UpdatedBy = loggedInUserId;
                                tutorOfferingDetail.CreatedDate = currentDateTime;
                                tutorOfferingDetail.UpdatedDate = currentDateTime;
                                tutorOfferingDetail.Subject = item.Subject;
                                tutorOfferingDetail.AgeGroup = item.AgeGroup;
                                tutorOfferingDetail.HourlyRate = item.HourlyRate;

                                lstTutorOfferingDetail.Add(tutorOfferingDetail);
                            }
                        }
                        await _dbContext.TutorOfferingDetails.AddRangeAsync(lstTutorOfferingDetail);
                        await _dbContext.SaveChangesAsync();

                        var tokenDetail = await _commonRepo.TokenMstList().FirstOrDefaultAsync(x => x.UserId == request.Id);

                        userDetail.UpdatedBy = loggedInUserId;
                        userDetail.UpdatedDate = currentDateTime;
                        userDetail.FirstName = request.FirstName;
                        userDetail.LastName = request.LastName;
                        userDetail.PhoneNo = request.PhoneNo;
                        userDetail.TimeZone = request.TimeZone;
                        userDetail.PlatformPreference = request.PlatformPreference;
                        userDetail.PlatformLink = request.PlatformLink;
                        if (tokenDetail != null)
                        {
                            userDetail.LastLogin = tokenDetail.UpdatedDate.Date;
                        }

                        _dbContext.Entry(userDetail).State = EntityState.Modified;
                        await _dbContext.SaveChangesAsync();

                        resDTO.Id = userDetail.Id;
                        response.Data = resDTO;
                        response.Status = true;
                        response.Message = "User Updated Successfully!";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {
                    response.Message = "Id is invalid!";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
    }
}
