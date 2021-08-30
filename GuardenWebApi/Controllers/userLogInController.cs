using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using GuardenWebApi.DTO;
using GuardenClassLibrary.EF;
using System.Net;
using System.Net.Mail;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;


namespace GuardenWebApi.Controllers
{
    public class userLogInController : ApiController
    {
        
        public IHttpActionResult POST([FromBody] userLogInDTO u)
        {
            try
            {
                GuardenClassLibrary.EF.userLoginResultDTO userLoginResult = tblUser.CheckUserLogIn(u.Email, u.Password);
                
                return Ok(userLoginResult);
            }
            catch (NullReferenceException )
            {
                return Ok(false);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

    }

}
