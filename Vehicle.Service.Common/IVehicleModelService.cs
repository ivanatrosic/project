using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Models;
using Vehicle.Paging;

namespace Vehicle.Service
{
    public interface IVehicleModelService
    {
        Task<int> InsertAsync(IVehicleModel item);
        Task<int> UpdateAsync(IVehicleModel item);
        Task<int> DeleteAsync(IVehicleModel item);
        Task<int> DeleteAsync(Guid? id);
        Task<IEnumerable<IVehicleModel>> GetAsync(IPagingDetails pagingDetails);
        Task<IVehicleModel> GetAsync(Guid? ID);
        Task<IEnumerable<IVehicleModel>> GetByMakeAsync(Guid? makeId, IPagingDetails pagingDetails);


    }
}
