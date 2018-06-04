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
            //libere les ressources,c# l utilise tout seul,on l implemente simplement
        }

        public void TruncatClients()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Clients");
            //efface la table sql Clients
            db.SaveChanges();   
        }



        #region client

        #region GetClients
        public List<Client> GetClients()
        {
            return db.Clients.ToList();
            //== select * from product en sql
        }

        #endregion

        #region AddClients
        public void AddClients(Client c)
        {
            db.Clients.Add(c);
            //ajoute le client
            //== insert into en sql
            db.SaveChanges();
            //sauvegarde
        }

        #endregion


        #region  Client GetClient
        public Client GetClient(int id)
        {
            return db.Clients.FirstOrDefault(x => (x.Id == id));
        }

        #endregion

        #region DeleteClient
        public void DeleteClient(int id)
        {
            Client exist = db.Clients.FirstOrDefault(x => (x.Id == id));
            if (exist != default(Client))
            {
                db.Clients.Remove(exist);
                db.SaveChanges();
            }
        }

        #endregion

        #region UpdateClient
        public void UpdateClient(Client c)
        {
            Client exist = db.Clients.FirstOrDefault(x => (x.Id == c.Id));
            //va rechercher dans la liste de produits,puis compare les identidifiants pour retrouver le meme
            if (exist != default(Client))//preferer default à "null" pour les cas ou le retour est 0 ou autre
            {
                exist.LastName = c.LastName;
                exist.FirstName = c.LastName;
                db.SaveChanges();

            }
        }

        #endregion

        #region GetClients Predicate
        public List<Client> GetClients(Predicate<Client> predicate)
        {

            List<Client> result = new List<Client>();
            //cree une liste de resultats
            foreach (Client c in db.Clients)
            //pour chaque client dans la base de donnée Client
            {
                if (predicate(c))
                //si le predicat correspond au Client demandé(p)
                {
                    result.Add(c);
                    //la liste ajoute le Client a result
                    db.SaveChanges();
                }
            }
            return result;
            //retourne la liste result
        }

        #endregion

        #endregion client

        #region product

        #region GetProducts
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
            //== select * from product en sql
        }
        #endregion


        public Product GetProduct(string reference)
        {
           return  db.Products.FirstOrDefault(x => (x.Reference == reference));
        }
        #region AddProduct
        public void AddProduct(Product p)
        {
            db.Products.Add(p);
            //ajoute le produits
            //== insert into en sql
            db.SaveChanges();
            //sauvegarde
        }
        #endregion

        #region Update Product
        public void UpdateProduct(Product p)
        {
            Product exist = db.Products.FirstOrDefault(x => (x.Id == p.Id));
            //va rechercher dans la liste de produits,puis compare les identidifiants pour retrouver le meme
            if (exist != default(Product))//preferer default à "null" pour les cas ou le retour est 0 ou autre
            {
                exist.ProductDescription = p.ProductDescription;
                exist.ProductName = p.ProductName;
                exist.ProductPrice = p.ProductPrice;
                db.SaveChanges();
            }
        }
        #endregion

        #region Product GetProduct
        public Product GetProduct(int id)
        {
            return db.Products.FirstOrDefault(x => (x.Id == id));
        }

        #endregion

        #region DeleteProduct
        public void DeleteProduct(int id)
        {
            Product exist = db.Products.FirstOrDefault(x => (x.Id == id));
            if (exist != default(Product))
            {
                db.Products.Remove(exist);
                db.SaveChanges();
            }


        }

        #endregion

        #region GetProducts Predicate
        public List<Product> GetProducts(Predicate<Product> predicate)
        {

            List<Product> result = new List<Product>();
            //cree une liste de resultats
            foreach (Product p in db.Products)
            //pour chaque produit dans la base de donnée product
            {
                if (predicate(p))
                //si le predicat correspond au produit demandé(p)
                {
                    result.Add(p);
                    //la liste ajoute le produit a result
                    db.SaveChanges();
                }
            }
            return result;
            //retourne la liste result
        }
        #endregion


        public void TruncatProducts()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE Products;");
            //efface la table sql Clients
            db.SaveChanges();
        }
        #endregion product
    }
}