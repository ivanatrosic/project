using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Models;
using Vehicle.Paging;
using Vehicle.Repository;

namespace Vehicle.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        protected IVehicleModelRepository Repository { get; private set; }

        public VehicleModelService(IVehicleModelRepository repository)
        {
            Repository = repository;

        }

        public Task<int> DeleteAsync(IVehicleModel item)
        {
            return Repository.DeleteAsync(item);
        }

        public Task<int> DeleteAsync(string id)
        {
            return Repository.DeleteAsync(id);
        }

        public Task<List<IVehicleModel>> GetByMakeAsync(string makeId, PagingDetails pagingDetails)
        {
            return Repository.GetByMakeAsync(makeId, pagingDetails);
        }

        public Task<List<IVehicleModel>> GetAsync(PagingDetails pagingDetails)
        {
            return Repository.GetAsync(pagingDetails);
        }

        public Task<IVehicleModel> GetAsync(string Id)
        {
            return Repository.GetAsync(Id);
        }

        public Task<int> InsertAsync(IVehicleModel item)
        {
            return Repository.InsertAsync(item);
        }

        public Task<int> UpdateAsync(IVehicleModel item)
        {
            return Repository.UpdateAsync(item);
        }
    }
}
