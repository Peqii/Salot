using Microsoft.AspNetCore.Mvc;
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
    public class WebsiteController : ControllerBase
    {
        private SalotDBContext _db;
        private static IConfiguration _configuration;
        public WebsiteController(SalotDBContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        [Route("Get")]
        [HttpGet]
        public ActionResult GetWebsites()
        {
            try 
            {
                var websites = _db.Websites.ToList();
                return Ok(websites);
            }
            catch(Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.Message);
            }
        }
        [Route("GetUserWebsites/{id}")]
        [HttpGet]
        public ActionResult GetWebsitesWithUserId(Guid userGuid)
        {
            try
            {
                var websites = _db.Websites.Where(w => w.UserId == userGuid).ToList();
                List<Salot.Data.Website> websiteModels = new List<Salot.Data.Website>();
                foreach (Website website in websites)
                    websiteModels.Add(ModelCreator.CreateModelWebsite(website));
                return Ok(websiteModels);
            }
            catch(Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.Message);
            }
        }
        [Route("Insert")]
        [HttpPost]
        public ActionResult InsertWebsite(Salot.Data.Website website)
        {
            try
            {
                Website newSite = ModelCreator.CreateWebsite(website);
                _db.Websites.Add(newSite);
                _db.SaveChanges();

                var websites = _db.Websites.Where(w => w.UserId == website.UserId).ToList();
                List<Salot.Data.Website> websiteModels = new List<Salot.Data.Website>();
                foreach (Website w in websites)
                    websiteModels.Add(ModelCreator.CreateModelWebsite(w));
                return Ok(websiteModels);

            }
            catch(Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.Message);
            }
        }
        [Route("DeleteWebsite/{id}")]
        [HttpDelete]
        public ActionResult InsertWebsite(Guid id)
        {
            try
            {
               
                _db.Websites.Remove(_db.Websites.Find(id));
                _db.SaveChanges();
                return Ok("Deleted");

            }
            catch (Exception ex)
            {
                LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
                return BadRequest(ex.Message);
            }
        }
        //[Route("UpdateWebsite")]
        //[HttpPut]
        //public ActionResult UpdateWebsite(Salot.Data.Website insertedWebsite)
        //{
        //    try
        //    {
        //        Website website = _db.Websites.Find(insertedWebsite.ID);

        //        website.Address = insertedWebsite.Address;
        //        _db.Websites.Attach(website);
        //        _db.SaveChanges();
        //        return Ok(website);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteToErrorLog(ex.Message, _configuration.GetValue<string>("LogFolder"), _configuration.GetValue<string>("LogFile"));
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
