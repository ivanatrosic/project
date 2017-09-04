using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.Repository;

namespace Vehicle.Service
{
   public interface IVehicleMakeService
    {
        VehicleMake GetById(int id);
        void Insert(VehicleMake item);
        void Update(VehicleMake item);
        void Delete(VehicleMake item);
        IEnumerable<VehicleMake> Find(Expression<Func<VehicleMake, bool>> predicate);
        IEnumerable<VehicleMake> GetAll();
        IEnumerable<VehicleMake> Filter(string filter);

    }
}
