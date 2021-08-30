using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuardenWebApi.DTO
{
    public class UserOtpDTO
    {
        public string Email { get; set; }

        public int OTP { get; set; }
    }
}