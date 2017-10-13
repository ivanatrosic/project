using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Models;
using Vehicle.Repository;
using Vehicle.Common;

namespace Vehicle.Repository
{
    public interface IVehicleMakeRepository
    {

        Task<IEnumerable<IVehicleMake>> GetAsync(IPagingDetails pagingDetails);
        Task<IEnumerable<IVehicleMake>> GetAsync();
        Task<int> InsertAsync(IVehicleMake item);
        Task<int> UpdateAsync(IVehicleMake item);
        Task<IVehicleMake> GetAsync(Guid? id);
        Task<int> DeleteAsync(IVehicleMake item);
        Task<int> DeleteAsync(Guid? id);





    }
}