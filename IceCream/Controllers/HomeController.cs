﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCream.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Why Dragon Scoops?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We'd love to hear from you!";

            return View();
        }
    }
}