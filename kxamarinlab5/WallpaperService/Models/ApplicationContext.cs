using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WallpaperService.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        { }
        public DbSet<Wallpaper> Wallpapers { get; set; }
    }
}