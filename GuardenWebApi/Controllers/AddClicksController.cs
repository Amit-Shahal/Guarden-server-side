using GuardenClassLibrary.EF;
using GuardenWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;


namespace GuardenWebApi.Controllers
{
    [RoutePrefix("api/AddClicks")]
    public class AddClicksController : ApiController
    {
        [HttpGet]
        [Route("ToArea/{id:int}")]
        // GET api/<controller>/5
        public IHttpActionResult ToArea(int id)
        {
            try
            {
                GuardenDB db = new GuardenDB();
                return Ok(tblUser.AddClicksToArea(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}