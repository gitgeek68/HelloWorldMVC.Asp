﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Liste", "Client");
        }




        public String Bonjour()
        {
            return "Bonjour les developpeurs!";
        }

     
    }
}
