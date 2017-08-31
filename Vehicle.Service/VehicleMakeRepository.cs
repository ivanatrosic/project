using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;

namespace Vehicle.Service
{
    public class VehicleMakeRepository: IVehicleMakeRepository
    {
        private VehicleContext context;

        public VehicleMakeRepository(VehicleContext vehicleContext)
        {
            context = vehicleContext;

        }

        public IEnumerable<VehicleMake> GetVehicleMake()
        {
            return context.VehicleMake.ToList();
        }

        public VehicleMake GetVehicleMakeById(int id)
        {
            return context.VehicleMake.Find(id);
        }

        public void InsertVehicleMake(VehicleMake vehicleMake)
        {
            context.VehicleMake.Add(vehicleMake);
        }

        public void DeleteVehicleMake(int id)
        {
            VehicleMake vehicleMake = context.VehicleMake.Find(id);
            context.VehicleMake.Remove(vehicleMake);
        }

        public void UpdateVehicleMake(VehicleMake vehicleMake)
        {
            context.Entry(vehicleMake).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
