using QandA_App.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA_App.Models
{
    public class PostQuestionRequest
    {
        public int QuestionId { get; set; }
        public string UserAsked { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeAsked { get; set; }

    }
}