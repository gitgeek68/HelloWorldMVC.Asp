using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMVC.Models
{
    public class Dal : IDisposable
    {
        private BddContext db;

        public Dal()
        {
            db = new BddContext();
    }

        public void Dispose()
        {
            db.Dispose();
        }
        #region Product
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
            //== select * from product en sql
        }

        public void AddProduct(Product p)
        {
            db.Products.Add(p);
            //ajoute le produits
            //== insert into en sql
            db.SaveChanges();
            //sauvegarde
        }
        #endregion Product

        #region client
        public List<Client> GetClients()
        {
            return db.Clients.ToList();
            //== select * from product en sql
        }

        public void AddClients(Client c)
        {
            db.Clients.Add(c);
            //ajoute le client
            //== insert into en sql
            db.SaveChanges();
            //sauvegarde
        }
        #endregion client
    }
}