using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace Vehicle.Service
{
    class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleMakeService>().To<VehicleMakeService>();
            Bind<IVehicleModelService>().To<VehicleModelService>();
        }
    }
}
