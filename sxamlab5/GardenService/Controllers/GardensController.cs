using GardenService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GardenService.Controllers
{
    public class GardensController : ApiController
    {
        ApplicationContext db = new ApplicationContext();
        public IEnumerable<Garden> Get()
        {
            return db.Gardens.ToList();
        }

        public Garden Get(int id)
        {
            return db.Gardens.Find(id);
        }

        public IHttpActionResult Post([FromBody] Garden garden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Gardens.Add(garden);
            db.SaveChanges();
            return Ok(garden);
        }

        public IHttpActionResult Put([FromBody] Garden garden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(garden).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(garden);
        }

        public IHttpActionResult Delete(int id)
        {
            Garden garden = db.Gardens.Find(id);
            if (garden != null)
            {
                db.Gardens.Remove(garden);
                db.SaveChanges();
                return Ok(garden);
            }
            return NotFound();
        }
    }
}