using QandA_App.DataLayer;
using QandA_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QandA_App.Controllers
{
    public class AnswerController : ApiController
    {
        private readonly QandABagContext _dbContext;

        public AnswerController()
        {
            _dbContext = new QandABagContext();
        }




        [HttpPost]
        [Route("api/Question/{id}/Answer")]  //Api access path.
        public RegisterResponse PostAnswer(int id, PostAnswerRequest request)
        {

            // Check uniqueness in Answer  
            //var isExist = _dbContext.Answres
            //    .Where(c => c.AnswerDetails == request.AnswerDetails)
            //    .SingleOrDefault();
            // fetches the user details from the database 
            var user = _dbContext.Users
               .Where(u => u.UserName == request.UserAnswered)
               .FirstOrDefault();
            var question = _dbContext.Questions
               .Where(u => u.QuestionId == id)
               .FirstOrDefault();

            //if (isExist == null)
            //{
            // if no such answer exist in database, so insert it to the database
            var answer = new Answer
            {
                AnswerDetails = request.AnswerDetails,
                DateTimeAnswered = DateTime.Now,
                QuestionId = id,
                UserAnswered = user,
                Question = question
            };

            var questionupdate = new Question
            {
                QuestionId = question.QuestionId,
                Title = question.Title,
                Description = question.Description,
                Status = true,
                AnswerCount = question.AnswerCount + 1,
                UserAsked = question.UserAsked,
                DateTimeAsked = question.DateTimeAsked
            };
                

            try
            {
                // save the changes to the database
                _dbContext.Answres.Add(answer);
                _dbContext.Questions.AddOrUpdate(questionupdate);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return new RegisterResponse
                {   //response to the client in the case of database failure.
                    Valid = true,
                    Message = e.Message
                };
            }

            return new RegisterResponse
            {   //response to the client in the case of successful insertion of answer.
                Valid = true,
                Message = "Answer Inserted Sucessfully"
            };
            //}
            //else
            //    return new RegisterResponse
            //    {  //response to the client in the case of question duplication.
            //        Valid = false,
            //        Message = "Answer already exist in the data base"
            //    };

        }



        
        [HttpGet]
        [Route("api/Question/{id}")]
        public AnswerCollection AllAnswer(int id)
        {
            

            var answers = _dbContext.Answres
                .Where(c => c.QuestionId == id);
            if (answers != null)
            {
                var answerList = from c in answers
                                 select new AnswerResponse
                                 {
                                     AnswerDetails = c.AnswerDetails,
                                     DateTimeAnswered = c.DateTimeAnswered.ToString(),
                                     QuestionId = c.QuestionId,
                                     UserAnswered = c.UserAnswered.UserName

                                 };
                return new AnswerCollection
                {
                    Answers = answerList,
                    Valid = true,
                    Message = "Sucessfully posted your answer"
                };
            }
            else
                return new AnswerCollection
                {
                    Answers = null,
                    Valid = false,
                    Message = "Answer is not posted due to some internal error "
                };
        }
                

    }
}
