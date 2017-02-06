﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA_App.Models
{
    public class RegisterRequest
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
    }
}