using Microsoft.AspNet.Identity.EntityFramework;
using SASPLabs_2_4.Models.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SASPLabs_2_4.Models
{
    public class WaffleContext : IdentityDbContext<ApplicationUser>
    {
        public WaffleContext()
            : base("WaffleContext")
        { }

        public static WaffleContext Create()
        {
            return new WaffleContext();
        }

        public DbSet<Waffle> Waffles { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}