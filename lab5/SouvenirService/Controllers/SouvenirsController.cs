using SouvenirService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SouvenirService.Controllers
{
    public class SouvenirsController : ApiController
    {
        ApplicationContext db = new ApplicationContext();
        public IEnumerable<Souvenir> Get()
        {
            return db.Souvenirs.ToList();
        }

        public Souvenir Get(int id)
        {
            return db.Souvenirs.Find(id);
        }

        public IHttpActionResult Post([FromBody] Souvenir souvenir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Souvenirs.Add(souvenir);
            db.SaveChanges();
            return Ok(souvenir);
        }

        public IHttpActionResult Put([FromBody] Souvenir souvenir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(souvenir).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(souvenir);
        }

        public IHttpActionResult Delete(int id)
        {
            Souvenir souvenir = db.Souvenirs.Find(id);
            if (souvenir != null)
            {
                db.Souvenirs.Remove(souvenir);
                db.SaveChanges();
                return Ok(souvenir);
            }
            return NotFound();
        }
    }
}