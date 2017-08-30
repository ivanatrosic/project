﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.DAL;

namespace Vehicle.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var entities = new VehicleContext();

            return View(entities.VehicleMake.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}