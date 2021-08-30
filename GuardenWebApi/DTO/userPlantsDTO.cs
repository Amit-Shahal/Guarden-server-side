using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GuardenWebApi.DTO
{
    public class userPlantsDTO
    {
        public int Plant_ID { get; set; }
        public string Plant_Name { get; set; }
        public string Plant_Category { get; set; }
        public string Plant_Lifecycle_Level { get; set; }
        public int? PlantWaterCycleInMinutes { get; set; }
        public int? LastWateringInMinutes { get; set; }
        public List<PlantsPhotoArchiveDTO> PlantsPhotoArchive { get; set; }
    }
}