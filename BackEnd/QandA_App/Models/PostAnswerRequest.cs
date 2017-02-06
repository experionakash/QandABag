using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA_App.Models
{
    public class PostAnswerRequest
    {
        public int AnswerId { get; set; }
        public string UserAnswered { get; set; }
        public string AnswerDetails { get; set; }
        public DateTime DateTimeAnswered { get; set; } 
    }
}