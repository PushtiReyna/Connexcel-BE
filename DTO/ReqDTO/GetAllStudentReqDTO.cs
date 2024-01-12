using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class GetAllStudentReqDTO
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public bool OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
