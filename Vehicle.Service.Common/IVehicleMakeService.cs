using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Repository;
using Vehicle.Paging;
using Vehicle.Models;

namespace Vehicle.Service
{
   public interface IVehicleMakeService
    {
 
        Task<int> InsertAsync(IVehicleMake item);
        Task<int> UpdateAsync(IVehicleMake item);
        Task<int> DeleteAsync(IVehicleMake item);
        Task<int> DeleteAsync(Guid? id);
        Task<IEnumerable<IVehicleMake>> GetAsync(IPagingDetails pagingDetails);
        Task<IEnumerable<IVehicleMake>> GetAsync();
        Task<IVehicleMake> GetAsync(Guid? Id);

    }
}
