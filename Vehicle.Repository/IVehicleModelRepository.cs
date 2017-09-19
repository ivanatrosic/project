using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Models;
using Vehicle.Paging;

namespace Vehicle.Repository
{
    public interface IVehicleModelRepository
    {
        Task<List<IVehicleModel>> GetAsync(PagingDetails pagingDetails);
        Task<List<IVehicleModel>> GetByMakeAsync(string filter, PagingDetails pagingDetails);
        Task<int> InsertAsync(IVehicleModel item);
        Task<int> UpdateAsync(IVehicleModel item);
        Task<IVehicleModel> GetAsync(string id);
        Task<int> DeleteAsync(IVehicleModel item);
        Task<int> DeleteAsync(string id);
    }
}
