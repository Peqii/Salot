using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Salot.Helpers;
using SalotAPI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private SalotDBContext _db;
        static private IConfiguration _configuration;
        public HumanController(SalotDBContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var humans = _db.Humans.ToList();

                return Ok(humans);
            }
            catch(Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.Message);
            }
        }
        [Route("Get/{id}")]
        [HttpGet]
        public IActionResult GetHuman(Guid id)
        {
            if (id == null || id == Guid.Empty)
                return BadRequest("ID is empty");
            try
            {
                var human = _db.Humans.Where(h => h.Id == id).FirstOrDefault();
                return Ok(human);
            }
            catch
            {
                LogHelper.WriteToErrorLog("Id not found", _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest("Id not found");
            }
        }
        [Route("Insert")]
        [HttpPost]
        public IActionResult InsertHuman(Salot.Data.Human insertedHuman)
        {
            try
            {
                Human human = ModelCreator.CreateHumanFromAPI(insertedHuman);
                _db.Add(human);
                _db.SaveChanges();
                return Ok(insertedHuman);
            }
            catch(Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.Message);
            }            
        }
        [Route("Update")] 
        [HttpPut]
        public IActionResult UpdateHuman(Salot.Data.Human insertedHuman)
        {
            try
            {
                Human human = _db.Humans.Find(insertedHuman.ID);

                human.Name = insertedHuman.Name;
                human.Age = insertedHuman.Age;
                _db.Humans.Attach(human);
                _db.SaveChanges();
                return Ok(human);
            }
            catch(Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.ToString());
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteHuman([FromRoute]Guid id)
        {
            if (id != Guid.Empty)
            {
                try
                {
                    _db.Humans.Remove(_db.Humans.Find(id));
                    _db.SaveChanges();
                    return Ok("Deleted");
                }
                catch(Exception ex)
                {
                    LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                    return BadRequest("Something went wrong");
                }
            }
            else
                return BadRequest("ID is Empty");
        }
    }
}
