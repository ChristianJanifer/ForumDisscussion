﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.ViewModel
{
    public class JWTokenVM
    {
        public string Messages { get; set; }
        public string Token { get; set; }
        public string[] Roles { get; set; }
    }
}