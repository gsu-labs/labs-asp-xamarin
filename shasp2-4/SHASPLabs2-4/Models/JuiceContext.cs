using Microsoft.AspNet.Identity.EntityFramework;
using SHASPLabs2_4.Models.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SHASPLabs2_4.Models
{
    public class JuiceContext : IdentityDbContext<ApplicationUser>
    {
        public JuiceContext()
            : base("JuiceContext")
        { }

        public static JuiceContext Create()
        {
            return new JuiceContext();
        }

        public DbSet<Juice> Juices { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}