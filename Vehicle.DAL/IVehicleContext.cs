using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.DAL
{
    public interface IVehicleContext :IDisposable
    {
         DbSet<VehicleMake> VehicleMake { get; set; }
         DbSet<VehicleModel> VehicleModel { get; set; }

    }
}
