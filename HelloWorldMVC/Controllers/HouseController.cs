using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldMVC.Controllers
{
    public class HouseController : Controller
    {
        // GET: House
        public ActionResult Index()
        {
            ViewData["nom"] = "Michael";
            ViewData.Add("surnom", "Mike");
            return View("vue");
        }

        public string Salut(string id)
        {
            if (string.IsNullOrEmpty(id))
            {

                id = "les concepteurs";
            }
            return "salut " + id;
        }

        public string Liste(string id)
        {
            return @"<html>
                    <head>
                    <meta charset=""Utf-8"">
                    <title>Liste des courses</title>
                    </head>
                    <body>
                    <h1>Liste des courses de " + id + @" du " + DateTime.Now.ToLongDateString() + @"</h1> 
                            <ul>
                            <li>Eau</li>
                            <li>Lait</li>
                            <li>Materiels de camping</li>
                            </ul>
                    </body>
                    </html>";
        }
    }
}