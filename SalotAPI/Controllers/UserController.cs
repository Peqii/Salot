using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Salot.Helpers;
using SalotAPI.EF;
using SalotAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private SalotDBContext _db;
        IConfiguration _configuration;
        public UserController(SalotDBContext db, IConfiguration configuration)
        {
            _configuration = configuration;
            _db = db;
        }
        [Route("Get")]
        [HttpGet]
        public ActionResult GetUsers()
        {
            try 
            {
                var users = _db.Users.ToList();
                return Ok(users);
            }
            catch(Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.Message);
            }
        }
        [Route("Login")]
        [HttpPost]
        public ActionResult GetUser(Salot.Data.User apiUser)
        {
            try
            {
                UserHelper helper = new UserHelper();
                List<User> user = _db.Users.Where(w => w.Email == apiUser.Email).ToList();
                if (user == null)
                {
                    return BadRequest("Wrong username or password");
                }

                if (helper.ValidateInsertedCredentials(apiUser.Email, apiUser.Password, out ArgumentException exception))
                {
                    //Needed to create temphelper because for some reason nuget stopped working in the Data Project
                    var userPassword = TempHelper.GenerateHashedPassword(string.Concat(_configuration.GetValue<string>("PepperForAPI"), apiUser.Password), user.FirstOrDefault().Salt);
                    if( _db.Users.Any(u => u.Id == user.FirstOrDefault().Id && u.Password.Equals(userPassword)))
                        return Ok(user);
                   else
                        return BadRequest("Wrong username or password");
                }
                else
                {
                    return BadRequest(exception.Message);
                }
            }
            catch(Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.Message);
            }
        }
        [Route("register")]
        [HttpPost]
        public ActionResult InsertUser(Salot.Data.User apiUser)
        {
            try
            {
                if (_db.Users.Any(w => w.Email == apiUser.Email))
                {
                    return BadRequest("Email address already registered");
                }

                Salot.Helpers.UserHelper helper = new Salot.Helpers.UserHelper();
                if(helper.ValidateInsertedUserData(apiUser, out ArgumentException argumentException))
                {
                    User user = ModelCreator.CreateUser(apiUser);

                    string pepper = _configuration.GetValue<string>("PepperForAPI");
                    TempHelper tempHelper = new TempHelper(pepper);
                    Tuple<string, string> userPassSalt = tempHelper.GenerateUserPassword(apiUser.Password);

                    user.Password = userPassSalt.Item1;
                    user.Salt = userPassSalt.Item2;

                    _db.Users.Add(user);
                    _db.SaveChanges();

                    return Ok(user);
                }

                return BadRequest(argumentException.Message);
            }
            catch(Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.Message);
            }
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public ActionResult DeleteUser(Guid id)
        {
            try
            { 
                _db.Users.Remove(_db.Users.Find(id));
                _db.SaveChanges();
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.Message);
            }
        }
        //[Route("update")]
        //[HttpPut]
        //public ActionResult UpdateUser(Salot.Data.User insertedUser)
        //{
        //    //try
        //    //{
        //    //    User user = _db.Users.Find(insertedUser.ID);

        //    //    _db.Users.Attach(user);
        //    //    _db.SaveChanges();
        //    //    return Ok(user);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return BadRequest(ex.Message);
        //    //}
            
        //}
    }
}
