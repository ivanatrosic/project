[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Vehicle.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Vehicle.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Vehicle.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Vehicle.Repository;
    using Vehicle.Service;

    using System.Data.Entity;
    using System.Linq;
    using Vehicle.Models;
    using Vehicle.DAL;
    using Vehicle.Repository.Common;
    using Ninject.Extensions.Factory;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var settings = new NinjectSettings();
            settings.LoadExtensions = true;
            settings.ExtensionSearchPatterns = settings.ExtensionSearchPatterns
                .Union(new string[] { "Vehicle.*.dll" }).ToArray();
            var kernel = new StandardKernel(settings);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind<IRepository>().To<Repository>();
            kernel.Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>();
            kernel.Bind<IVehicleModelRepository>().To<VehicleModelRepository>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            kernel.Bind<IVehicleMakeService>().To<VehicleMakeService>();
            kernel.Bind<IVehicleModelService>().To<VehicleModelService>();

            kernel.Bind<IVehicleMake>().To<VehicleMakeDTO>();
            kernel.Bind<IVehicleModel>().To<VehicleModelDTO>();
            kernel.Bind<IVehicleContext>().To<VehicleContext>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IUnitOfWorkFactory>().ToFactory();
            kernel.Bind(typeof(DbContext)).To(typeof(VehicleContext));

        }
    }
}
