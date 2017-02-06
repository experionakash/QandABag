using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA_App.DataLayer
{
    public class Question
    {
        public int QuestionId { get; set; }
        public virtual User UserAsked { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int AnswerCount { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public DateTime DateTimeAsked { get; set; }

    }
}