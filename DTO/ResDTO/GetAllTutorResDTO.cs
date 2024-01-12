using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResDTO
{
    public class GetAllTutorResDTO
    {
        public int TotalCount { get; set; }
        public dynamic UserLists { get; set; }
    }
}
