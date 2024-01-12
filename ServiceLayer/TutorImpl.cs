using BussinessLayer;
using Helper.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class TutorImpl : ITutor
    {
        private readonly TutorBLL _tutorBLL;

        public TutorImpl(TutorBLL tutorBLL)
        {
          _tutorBLL = tutorBLL;
        }
        public async Task<CommonResponse> GetAllTutor() => await _tutorBLL.GetAllTutor();
    }
    public interface ITutor
    {
        public Task<CommonResponse> GetAllTutor();
    }
}
