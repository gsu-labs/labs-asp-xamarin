using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SHASPLab1.Models
{
    public class JuiceContext : DbContext
    {
        public DbSet<Juice> Juices { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}