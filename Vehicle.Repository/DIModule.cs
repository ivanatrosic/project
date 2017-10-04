using Ninject.Modules;
using Ninject.Extensions.Factory;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{


    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<Repository>();
            Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkFactory>().ToFactory();
        }
    }
}
