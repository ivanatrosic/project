using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Models;
using Vehicle.Repository;
using Vehicle.Paging;

namespace Vehicle.Service
{
   public interface IVehicleMakeService
    {
 
        Task<int> InsertAsync(IVehicleMake item);
        Task<int> UpdateAsync(IVehicleMake item);
        Task<int> DeleteAsync(IVehicleMake item);
        Task<int> DeleteAsync(string id);
        Task<List<IVehicleMake>> GetAsync(IPagingDetails pagingDetails);
        Task<IVehicleMake> GetAsync(string Id);

    }
}
