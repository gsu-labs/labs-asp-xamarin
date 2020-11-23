using MovieService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieService.Controllers
{
    public class MovieController : ApiController
    {
        ApplicationContext db = new ApplicationContext();
        public IEnumerable<Movie> Get()
        {
            return db.Movies.ToList();
        }

        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        public IHttpActionResult Post([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Movies.Add(movie);
            db.SaveChanges();
            return Ok(movie);
        }

        public IHttpActionResult Put([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(movie);
        }

        public IHttpActionResult Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
                return Ok(movie);
            }
            return NotFound();
        }
    }
}