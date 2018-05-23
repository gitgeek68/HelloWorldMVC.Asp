using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorldMVC.Models;

namespace HelloWorldMVC.Controllers
{
    public class ClientController : Controller
    {
        static Client client;
        // GET: Client
        public ActionResult Index()
        {
            return RedirectToAction("Liste");

        }

        static public List<Client> clientele = new List<Client>()
        {
            new Client(1,"jean","riz"),
            new Client(2,"patate","douce"),
            new Client(3,"rene","Courgette"),
            new Client(4,"Dauphin","malin")
        };




        public ActionResult Liste()
        {

            return View(clientele);
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Client c)
        {
            if (clientele.Count > 0)
            {
                c.Id = clientele.Max(x => x.Id) + 1;

            }
            else
            {
                c.Id = 1;
            }

            if (!ModelState.IsValid)
            {
                return View("Create", c);
            }
            clientele.Add(c);

            return RedirectToAction("Liste");
        }

        public ActionResult Edit(int id)
        {
            /*foreach (Client x in clientele)
            {
                if (x.Id == id)
                {
                    Client c = x;
                }
            }*/
            Client c = clientele.FirstOrDefault(x => (x.Id == id));
            /*recherche dans client list un element dont l identifiant correspond à l id dans l url*/

            if (c != default(Client))
            {
                return View(c);
            }
            return RedirectToAction("Liste");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Client c)
        {
            Client exist = clientele.FirstOrDefault(X => X.Id == c.Id);
            if (exist != default(Client))
            {
                exist.FirstName = c.FirstName;
                exist.LastName = c.LastName;
                // Classes.Loader.SaveClient("Liste");
            }
            return RedirectToAction("Liste");
        }

        public ActionResult Delete(int id)
        {
            Client c = clientele.FirstOrDefault(x => (x.Id == id));
            if (c != default(Client))
            {
                return View(c);
            }
            return RedirectToAction("Liste");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client c = clientele.FirstOrDefault(x => (x.Id == id));
            if (c != default(Client))
            {
                if (clientele.Remove(c))
                {
                    /* Classes.Loader.SaveClients();*/
                }
               
            }
            return RedirectToAction("Liste ");
        }

            public ActionResult Details(int id)
            {
            Client exist = clientele.FirstOrDefault(X => X.Id == id);
            if (exist != default(Client))
            {
                return View(exist);
            }
            return RedirectToAction("Liste");

        }
       

    }
    }