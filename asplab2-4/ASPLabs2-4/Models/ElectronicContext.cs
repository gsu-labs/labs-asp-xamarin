using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPLabs2_4.Models
{
    public class ElectronicContext : IdentityDbContext<ApplicationUser>
    {
        public ElectronicContext()
            : base("ElectronicContext")
        { }

        public static ElectronicContext Create()
        {
            return new ElectronicContext();
        }

        public DbSet<Electronic> Electronics { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}