using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WallpaperService.Models;

namespace WallpaperService.Controllers
{
    public class WallpapersController : ApiController
    {
        ApplicationContext db = new ApplicationContext();
        public IEnumerable<Wallpaper> Get()
        {
            return db.Wallpapers.ToList();
        }

        public Wallpaper Get(int id)
        {
            return db.Wallpapers.Find(id);
        }

        public IHttpActionResult Post([FromBody] Wallpaper wallpaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Wallpapers.Add(wallpaper);
            db.SaveChanges();
            return Ok(wallpaper);
        }

        public IHttpActionResult Put([FromBody] Wallpaper wallpaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(wallpaper).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(wallpaper);
        }

        public IHttpActionResult Delete(int id)
        {
            Wallpaper wallpaper = db.Wallpapers.Find(id);
            if (wallpaper != null)
            {
                db.Wallpapers.Remove(wallpaper);
                db.SaveChanges();
                return Ok(wallpaper);
            }
            return NotFound();
        }
    }
}