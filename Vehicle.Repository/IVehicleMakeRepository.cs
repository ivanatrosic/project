using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.Repository;

namespace Vehicle.Repository
{
    public interface IVehicleMakeRepository : IRepository<VehicleMake>
    {
        VehicleMake GetById(int id);
        IEnumerable <VehicleMake> GetAll();
        //IEnumerable<VehicleMake> SortVehicleMake(IEnumerable<VehicleMake> vehicleMake);
        //IEnumerable<VehicleMake> SearchVehicleMake(string SearchString);



    }
}