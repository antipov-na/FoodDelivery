﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Core
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
