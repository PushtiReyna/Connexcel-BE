﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class CreateTokenReqDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
