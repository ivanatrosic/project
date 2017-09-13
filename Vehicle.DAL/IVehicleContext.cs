using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.DAL
{
    public interface IVehicleContext :IDisposable
    {
         DbSet<VehicleMake> VehicleMake { get; set; }
         DbSet<VehicleModel> VehicleModel { get; set; }

        Task<int> SaveChangesAsync();

        DbEntityEntry<T> Entry<T>(T item) where T : class;

        DbSet<T> Set<T>() where T : class;

    }
}
