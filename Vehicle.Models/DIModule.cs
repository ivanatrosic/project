using Ninject.Modules;
using Vehicle.DAL;
using System.Data.Entity;

namespace Vehicle.Models
{


    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleMake>().To<VehicleMakeDTO>();
            Bind<IVehicleModel>().To<VehicleModelDTO>();

            Bind(typeof(DbContext)).To(typeof(VehicleContext));
        }
    }
}
