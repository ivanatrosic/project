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
 
        Task<int> InsertAsync(VehicleMake item);
        Task<int> UpdateAsync(VehicleMake item);
        Task<int> DeleteAsync(VehicleMake item);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<VehicleMake>> GetAllAsync();
        Task<IEnumerable<VehicleMake>> FilterAsync(string filter);
        //Task<IEnumerable<VehicleMake>> SortAsync();
        Task<VehicleMake> GetOneAsync(int ID);

    }
}
