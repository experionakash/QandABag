using QandA_App.DataLayer;
using QandA_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QandA_App.Controllers
{
    public class QuestionsController : ApiController
    {
        private readonly QandABagContext _dbContext;

        public QuestionsController()
        {
            _dbContext = new QandABagContext();
        }

        [HttpPost]
        [Route("api/AskQuestion")]  //Api access path.
        public RegisterResponse PostQuestion(PostQuestionRequest request)
        {
            
            // Check uniqueness in Question  
            var isExist = _dbContext.Questions
                .Where(c => c.Title == request.Title && c.Description == request.Description)
                .SingleOrDefault();
            // fetches the user details from the database 
            var user = _dbContext.Users
               .Where(u => u.UserName == request.UserAsked)
               .FirstOrDefault();

            if (isExist == null)
            {
                // if no such question exist in database, so insert it to the database
                var question = new Question
                {
                    Title = request.Title,
                    Description = request.Description,
                    Status = false,
                    AnswerCount = 0,
                    UserAsked = user,
                    Answers = { },
                    DateTimeAsked = DateTime.Now
                };
                try
                {
                    // save the changes to the database
                    _dbContext.Questions.Add(question);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    return new RegisterResponse
                    {   //response to the client in the case of database failure.
                        Valid = false,
                        Message = e.Message
                    };
                }

                return new RegisterResponse
                {   //response to the client in the case of successful insertion of question.
                    Valid = true,
                    Message =  "Question Inserted Sucessfully"
            };
            }
            else
                return new RegisterResponse
                {  //response to the client in the case of question duplication.
                    Valid = false,
                    Message = "username already exist in the data base"
                };

        }


        // function for fetching all questions in the database.
        [HttpGet]
        [Route("api/Questions")]
        public QuestionCollection AllQuestions()
        {
            var questions = _dbContext.Questions.AsEnumerable();
            IEnumerable<QuestionResponse> questionList = null;
            try
            {
                 questionList = from c in questions
                                   select new QuestionResponse
                                   {
                                       QuestionId = c.QuestionId,
                                       UserAsked = c.UserAsked.UserName,
                                       Title = c.Title,
                                       Description = c.Description,
                                       Status = c.Status,
                                       AnswerCount = c.AnswerCount,
                                       DateTimeAsked = c.DateTimeAsked.ToString()
                                   };
            }
            catch (Exception e)
            {
                return new QuestionCollection
                {
                    Questions = questionList,
                    Message = e.Message,
                    Valid = false
                };
            }

            return new QuestionCollection
            {
                Questions = questionList,
                Message = "",
                Valid = true
            };
        }





     




    }
}
