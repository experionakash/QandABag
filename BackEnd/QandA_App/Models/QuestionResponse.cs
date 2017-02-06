using QandA_App.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA_App.Models
{
    public class QuestionResponse
    {
        public int QuestionId { get; set; }
        public string UserAsked { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int AnswerCount { get; set; }
       // public ICollection<Answer> Answers { get; set; }
        public string DateTimeAsked { get; set; }
    }


    public class QuestionCollection
    {
        public IEnumerable<QuestionResponse> Questions { get; set; }
        public string Message { get; set; }
        public bool Valid { get; set; }
    }
}