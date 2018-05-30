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
                dal.AddProduct(new Product { Reference = "Gp20", ProductName = "Googlr Paly", ProductDescription = "abonnement", ProductPrice = 20 });
                //ajoute un produit à product

                List<Product> products = dal.GetProducts();
                //

                Assert.IsNotNull(products);
                //assert test les conditions
                Assert.AreEqual(1, products.Count);
                Assert.AreEqual("GP20", products[0].Reference);
                Assert.AreEqual("Google Play", products[0].ProductName);


            }
        }
    }
}
