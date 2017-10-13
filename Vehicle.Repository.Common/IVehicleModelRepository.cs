using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Models;
using Vehicle.Common;

namespace Vehicle.Repository
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<IVehicleModel>> GetAsync(IPaging paging, IFilter filter);
        Task<IEnumerable<IVehicleModel>> GetByMakeAsync(Guid? MakeId, IPaging paging);
        Task<int> InsertAsync(IVehicleModel item);
        Task<int> UpdateAsync(IVehicleModel item);
        Task<IVehicleModel> GetAsync(Guid? id);
        Task<int> DeleteAsync(IVehicleModel item);
        Task<int> DeleteAsync(Guid? id);
    }
}
