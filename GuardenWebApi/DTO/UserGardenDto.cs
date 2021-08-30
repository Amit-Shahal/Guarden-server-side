using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuardenWebApi.DTO
{
    public class UserGardenDto
    {
        public string Name { get; set; }
        public string ProfileImg { get; set; }
        public List<UserGurdenAreasDTO> UserGurdenAreasDTO { get; set; }
    }
}