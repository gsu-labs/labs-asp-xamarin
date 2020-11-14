using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SASPLab1.Models
{
    public class WaffleContext : DbContext
    {
        public DbSet<Waffle> Waffles { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}