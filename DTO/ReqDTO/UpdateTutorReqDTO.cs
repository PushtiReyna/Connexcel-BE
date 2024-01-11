﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class UpdateTutorReqDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string TimeZone { get; set; }
        public string? PlatformPreference { get; set; }
        public string? PlatformLink { get; set; }
        public List<TutorOfferingDetails> lstTutorOfferingDetails { get; set; }

        public class TutorOfferingDetails
        {
            public string Subject { get; set; }
            public string AgeGroup { get; set; }
            public string HourlyRate { get; set; }
        }
    }
}
