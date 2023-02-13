using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KASPLab1.Models
{
    public class ElectronicContext : DbContext
    {
        public DbSet<Electronic> Electronics { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}