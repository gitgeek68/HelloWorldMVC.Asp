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
        #region Update Product
        public void UpdateProduct(Product p)
        {
            Product exist = db.Products.FirstOrDefault(x =>(x.Id == p.Id));
            //va rechercher dans la liste de produits,puis compare les identidifiants pour retrouver le meme
            if(exist != default(Product))//preferer default à "null" pour les cas ou le retour est 0 ou autre
            {
                exist.ProductDescription = p.ProductDescription;
                exist.ProductName = p.ProductName;
                exist.ProductPrice = p.ProductPrice;
            }
        }
        #endregion

        public Product GetProduct(int id)
        {
          return db.Products.FirstOrDefault(x => (x.Id == id));
        }

        public void DeleteProduct(int id)
        {
            Product exist = db.Products.FirstOrDefault(x => (x.Id == id));
            if (exist != default(Product))
            {
                db.Products.Remove(exist);
            }


        }
        #region GetProducts Predicate
        public List<Product> GetProducts(Predicate<Product> predicate)
        {

            List<Product> result = new List<Product>();
            //cree une liste de resultats
            foreach(Product p in db.Products)
                //pour chaque produit dans la base de donnée product
            {
                if(predicate(p))
                    //si le predicat correspond au produit demandé(p)
                {
                    result.Add(p);
                    //la liste ajoute le produit a result
                }
            }
            return result;
            //retourne la liste result
        }
        #endregion
    }
}