using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GuardenWebApi.DTO
{
    public class UserGurdenAreasDTO
    {
        public int Area_ID { get; set; }
        public string Area_Name { get; set; }
        public string sunExposure { get; set; }
        public bool? isInDoor { get; set; }

        public List<userPlantsDTO> userPlants { get; set; }

        public List<AreasPhotoArchive> AreasPhotoArchive { get; set; }

    }
}