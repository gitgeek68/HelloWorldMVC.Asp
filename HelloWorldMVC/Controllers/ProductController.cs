using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorldMVC.Models;

namespace HelloWorldMVC.Controllers
{

    public class ProductController : Controller
    {

        // GET: Product
        public ActionResult Index()
        {
            return View(Produits);
        }

        static public List<Product> Produits = new List<Product>()
        {
        new Product("A001"){ProductName ="unity",ProductPrice = 1500, ProductDescription = "logiciel"},
        new Product("A024") { ProductName = "musique",ProductPrice = 15, ProductDescription = "mp3"},
        new Product("A003") { ProductName = "image",ProductPrice = 1, ProductDescription = "jpeg"},
        new Product("A007") { ProductName = "dvd",ProductPrice = 10, ProductDescription = "blueray"},
        };

        public ActionResult Create()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Product p)
        {
            bool isCorrect=false;
            for(int i=0;i<Produits.Count;i++)
            {
                if(p.Reference == Produits[i].Reference)//egale au predicat en dessous
                {
                    isCorrect = true;
                   
                }
              
            }
           if(isCorrect==false)
            {
                Produits.Add(p);
            }
            return RedirectToAction("Index");//redirection vers la vue index
        }

        public ActionResult Details(string id)
        {
            Product p = Produits.FirstOrDefault(x=>(x.Reference == id));
            /*le predicat au dessus recupere le produit dans la liste */

            if(p != default(Product))//si different du produit par defaut
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id )
        {
            Product p = Produits.FirstOrDefault(x => (x.Reference == id));

            if (p != default(Product))//si different du produit par defaut
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Product _p)
        {
            Product exist = Produits.FirstOrDefault(x => (x.Reference == _p.Reference));
            if(exist != default(Product))
            {
                exist.ProductName = _p.ProductName;
                exist.ProductDescription = _p.ProductDescription;
                exist.ProductPrice = _p.ProductPrice;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id )
        {
            Product p = Produits.FirstOrDefault(x => (x.Reference == id));

            if (p != default(Product))//si different du produit par defaut
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            Product p = Produits.FirstOrDefault(x => (x.Reference == id));
            if (p != default(Product))
            {
                if (Produits.Remove(p))
                {
                    /* Classes.Loader.SaveClients();*/
                }

            }
            return RedirectToAction("Index");
        }
    }
}