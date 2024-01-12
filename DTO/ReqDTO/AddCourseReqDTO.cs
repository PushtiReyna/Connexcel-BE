using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class AddCourseReqDTO
    {
        public string CourseType { get; set; } 
        public string NoofLessons { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal StudentDefaultRate { get; set; }
        public string CourseName { get; set; }
        public string Frequency { get; set; } 
        public string Subject { get; set; } 
        public string Tutors { get; set; } 
    }
}
