using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA_App.Models
{
    public class AnswerResponse
    {
        public int AnswerId { get; set; }
        public string UserAnswered { get; set; }
        public int QuestionId { get; set; }
        public string AnswerDetails { get; set; }
        public string DateTimeAnswered { get; set; }
    }

    public class AnswerCollection
    {
        public IEnumerable<AnswerResponse> Answers { get; set; }
        public string Message { get; set; }
        public bool Valid { get; set; }
    }
}