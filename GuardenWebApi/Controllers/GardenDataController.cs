using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuardenWebApi.DTO;
using GuardenClassLibrary.EF;

namespace GuardenWebApi.Controllers
{
    public class GardenDataController : ApiController
    {
 
        public IHttpActionResult Get(int id)
        {
            try
            {
                DateTime minDateTime = new DateTime(1753, 1, 1);// DateTime.MinValue;

                GuardenDB dB = new GuardenDB();
                UserGardenDto user = dB.tblUsers.Where(u => u.ID == id).Select(x => new UserGardenDto()
                {
                    Name = x.Name,
                    ProfileImg = x.ProfileImg,
                    UserGurdenAreasDTO = x.tblAreas.Select(a => new UserGurdenAreasDTO()
                    {
                        Area_ID = a.Area_ID,
                        Area_Name = a.Area_Name,
                        isInDoor = a.isInDoor,
                        sunExposure = a.sunExposure,
                        AreasPhotoArchive = a.tblArea_Photo_Archive.Select(ap => new AreasPhotoArchive()
                        {
                            Photo_ID = ap.Photo_ID,
                            Area_Photo = ap.Area_Photo,
                        }).ToList(),
                        userPlants = a.tblPlants.Select(p => new userPlantsDTO()
                        {
                            Plant_ID = p.Plant_ID,
                            Plant_Name = p.Plant_Name,
                            Plant_Category = p.Plant_Category,
                            Plant_Lifecycle_Level = p.Plant_Lifecycle_Level,
                            PlantWaterCycleInMinutes = System.Data.Entity.DbFunctions.DiffMinutes( minDateTime, p.PlantWaterCycle), //subtract minvalue 1753-01-01
                            LastWateringInMinutes = System.Data.Entity.DbFunctions.DiffMinutes(p.LastWatering,DateTime.Now),
                            PlantsPhotoArchive = p.tblPlant_Photo_Archive.Select(pp => new PlantsPhotoArchiveDTO()
                            {
                                Photo_ID = pp.Photo_ID,
                                Plant_Photo = pp.Plant_Photo,
                                LifeCycle = pp.LifeCycle,
                                dateOfCreate = pp.dateOfCreate.ToString(),
                            }).OrderByDescending(DOC => DOC.dateOfCreate).ToList()
                        }).ToList()
                    }).ToList()
                }).ToList().SingleOrDefault();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

    }
}