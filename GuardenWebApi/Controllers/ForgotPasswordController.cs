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
    [RoutePrefix("api/userLogin")]
    public class ForgotPasswordController : ApiController
    {
        [HttpPost]
        [Route("checkOtp")]
        public IHttpActionResult checkOtp([FromBody] UserOtpDTO u)
        {
            try
            {
                return Ok(tblUser.CheckOTP(u.Email, u.OTP));

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
        
        [HttpPost]
        [Route("sendOtpByEmail")]
        public IHttpActionResult sendOtpByEmail([FromBody] userForgotPasswordDTO u)
        {
            try
            {
                Random rnd = new Random();
                int otp = rnd.Next(100000, 999999);
                string name = null;
                 name = tblUser.CheckUserForgotPasswordAndUpdateOTP(u.Email, otp);
                if (name != null)
                {
                    // send email to clint 
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                    {
                        Credentials = new NetworkCredential("Guarden.App@Gmail.com", "guarden1234"),
                        EnableSsl = true
                    };
                    client.Send("Guarden.App@Gmail.com",
                        $"{u.Email}",
                        $"Guarden - Reset Password",
                        $"Hello dear {name} ,\n\nHope you take care of your plants better then your passwords 💚😎 \n" +
                        $"Here is the code to reset your password, switch back to Guarden App and enter: {otp}");
                }
                return Ok(name != null ? true : false);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
      
        [HttpPost]
        [Route("changeUserEmail")]
        public IHttpActionResult changeUserEmail([FromBody] UserNewPasswordDTO u)
        {
            try
            {
                bool changed = tblUser.ChangePassword(u.Email, u.Password);
                if (changed)
                {
                    // send email to clint 
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                    {
                        Credentials = new NetworkCredential("Guarden.App@Gmail.com", "guarden1234"),
                        EnableSsl = true
                    };
                    client.Send("Guarden.App@Gmail.com",
                        $"{u.Email}",
                        $"Guarden - Password Restarted Successfully",
                        $"Happy Guardening 🎄");
                }
                return Ok(changed);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}