using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuardenWebApi.DTO
{
    public class UserNewPasswordDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}