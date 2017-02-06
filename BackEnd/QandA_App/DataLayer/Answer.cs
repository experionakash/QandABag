using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA_App.DataLayer
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public virtual User UserAnswered { get; set; }
        public int QuestionId { get; set; }
        public string AnswerDetails { get; set; }
        public DateTime DateTimeAnswered { get; set; }
        public virtual Question Question { get; set; }
    }
}