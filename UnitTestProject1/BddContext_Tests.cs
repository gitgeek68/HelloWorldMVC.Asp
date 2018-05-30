using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldMVC.Models;

namespace HelloWorld_Tests
{
    [TestClass]
    public class BddContext_Tests
    {
        [TestMethod]
        public void Db_Product()
        {
            using (Dal dal = new Dal())
                //cree un object disponible qua dans le bloc du using
            {
                dal.AddProduct(new Product { Reference = "Gp20", ProductName = "Google Play", ProductDescription = "abonnement", ProductPrice = 20 });
                //ajoute un produit à product

                List<Product> products = dal.GetProducts();
                //

                Assert.IsNotNull(products);
                //assert test les conditions
                //Assert.AreEqual(2, products.Count);
                Assert.AreEqual("Gp20", products[0].Reference);
                Assert.AreEqual("Google Play", products[0].ProductName);


            }
        }

        [TestMethod]
        public void Db_Client()
        {
            using (Dal dal = new Dal())
            //cree un object disponible qua dans le bloc du using
            {
                dal.AddClients(new Client { Id = 1, FirstName= "Jean", LastName = "DE Lafontaine"});
                //ajoute un produit à product

                List<Client> clients = dal.GetClients();
                //

                Assert.IsNotNull(clients);
                //assert test les conditions
                Assert.AreEqual(1, clients.Count);
                Assert.AreEqual("Jean", clients[0].FirstName);
                Assert.AreEqual("DE Lafontaine", clients[0].LastName);


            }
        }
    }
}
