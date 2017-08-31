﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vehicle.DAL;


namespace Vehicle.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<VehicleContext>());


            //using (var ctx = new VehicleContext())
            //{
            //    ctx.Database.Initialize(false);
            //}

        }
    }
}
