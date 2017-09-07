using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vehicle.DAL;
using System.Web.Http;
using Autofac.Integration.Mvc;
using Autofac;
using Vehicle.MVC.Module;

namespace Vehicle.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var builder = new Autofac.ContainerBuilder();

            //builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            //builder.RegisterModule(new RepositoryModule());
            //builder.RegisterModule(new ServiceModule());
            //builder.RegisterModule(new EFModule());

            //var container = builder.Build();

            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
