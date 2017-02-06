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
    public class UserController : ApiController
    {
       
        private readonly QandABagContext _dbContext;

        public UserController()
        {
            _dbContext = new QandABagContext();
        }

        // Function for authenticating user
        [HttpPost]
        [Route("api/Login")] 
        public LoginResponse Login(LoginRequest request)
        {
            var users = _dbContext.Users.AsEnumerable();
            // check if any matching record found in the database to the user inputs.
            var user = _dbContext.Users.
                Where(u => u.UserName == request.UserName && u.Password == request.Password)
                .FirstOrDefault();

            if (user == null)
            {
                return new LoginResponse
                {   // response while no matching record found in database
                    Valid = false,
                    Message = "Incorrect UserName or password"
                };
            }

            return new LoginResponse
            {   // response while a matching record found in database
                Valid = true,
                Message = "Login Success"
            };
        }


        // Function for registering a new user.
        [HttpPost]
        [Route("api/Register")]  //Api access path.
        public RegisterResponse Register(RegisterRequest request)
        {
            // Check uniqueness for username  
            var isExist = _dbContext.Users
                .Where(c => c.UserName == request.UserName)
                .SingleOrDefault();
            if (isExist == null)
            {
                // if no such user exist in database create a new user
                var user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DOB = request.DOB,
                    UserName = request.UserName,
                    Password = request.Password,
                    Email = request.Email
                };
                try{
                    // save the changes to the database
                    _dbContext.Users.Add(user);
                    _dbContext.SaveChanges();
                }
                catch(Exception e) {
                    return new RegisterResponse
                    {   //response to the client in the case of database failure.
                        Valid = true,
                        Message = e.Message

                    };
                }

                return new RegisterResponse
                {   //response to the client in the case of successful insertion of user.
                    Valid = true,
                    Message =  "User Inserted Sucessfully"

            };
            }
            else
                return new RegisterResponse
                {  //response to the client in the case of username duplication.
                    Valid = false,
                    Message = "username already exist in the data base"
                };

        }
    }
}
