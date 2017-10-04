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
            try
            { 
            return Repository.DeleteAsync(item);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> DeleteAsync(Guid? id)
        {
            try { 
            return Repository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<IEnumerable<IVehicleModel>> GetByMakeAsync(Guid? makeId, IPagingDetails pagingDetails)
        {
            try
            { 
            return Repository.GetByMakeAsync(makeId, pagingDetails);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<IEnumerable<IVehicleModel>> GetAsync(IPagingDetails pagingDetails)
        {
            try
            { 
            return Repository.GetAsync(pagingDetails);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<IVehicleModel> GetAsync(Guid? Id)
        {
            try
            { 
            return Repository.GetAsync(Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> InsertAsync(IVehicleModel item)
        {
            try
            {
            return Repository.InsertAsync(item);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> UpdateAsync(IVehicleModel item)
        {
            try
            {
            return Repository.UpdateAsync(item);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
