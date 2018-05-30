using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;//utliser les class de entity framework


namespace HelloWorldMVC.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Product> Products
        {
            //liste de produits stocker dans l accesseur product
            get;set;
        }

        public DbSet<Client> Clients
        {
            //liste des clients stocker dans l accesseur Clients
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BddContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}