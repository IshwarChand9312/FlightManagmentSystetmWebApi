﻿using System;
using System.Collections.Generic;

namespace fmsapi.Models
{
    public partial class IUser
    {
        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
    }
}
