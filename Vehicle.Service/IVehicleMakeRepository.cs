using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;

namespace Vehicle.Service
{
    public interface IVehicleMakeRepository : IDisposable
    {
        IEnumerable<VehicleMake> GetVehicleMake();
        VehicleMake GetVehicleMakeById(int Id);
        void InsertVehicleMake(VehicleMake vehiclemake);
        void DeleteVehicleMake(int id);
        void UpdateVehicleMake(VehicleMake vehiclemake);
        void Save();
    }
}
