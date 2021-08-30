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
    public class PlantController : ApiController
    {
        

       
        // PUT api/<controller>/5
        public void Put(int id)
        {
            try
            {
                GuardenDB db = new GuardenDB();
                tblPlant plant = db.tblPlants.Where(p => p.Plant_ID == id).SingleOrDefault();
                if (plant != null)
                {
                    plant.LastWatering = DateTime.Now;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
            
        }

        
    }
}