using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GuardenWebApi.DTO
{
    public class PlantsPhotoArchiveDTO
    {
        public int Photo_ID { get; set; }
        public string Plant_Photo { get; set; }

        public string LifeCycle { get; set; }

        public string dateOfCreate { get; set; }

    }
}