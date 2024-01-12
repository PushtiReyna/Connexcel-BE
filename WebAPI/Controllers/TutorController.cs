using Azure.Core;
using DTO.ReqDTO;
using DTO.ResDTO;
using Helper.CommonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using WebAPI.ViewModel.ResViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        public readonly ITutor _iTutor;
        public TutorController(ITutor iTutor)
        {
            _iTutor = iTutor;
        }

        [HttpGet("GetAllTutor")]
        public async Task<CommonResponse> GetAllTutor()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iTutor.GetAllTutor();
            }
            catch { throw; }
            return response;
        }
    }
}
