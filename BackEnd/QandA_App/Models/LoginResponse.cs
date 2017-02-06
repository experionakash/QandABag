using QandA_App.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA_App.Models
{
    public class LoginResponse
    {
        public bool Valid { get; set; }
        public string Message { get; set; }

    }
}