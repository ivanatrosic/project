using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Repository;
using Vehicle.Paging;
using System.Linq.Expressions;
using Vehicle.Models;

namespace Vehicle.Service
{
    public class VehicleMakeService :IVehicleMakeService
    {
        protected IVehicleMakeRepository Repository { get; private set; }

        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            Repository = repository;
  
        }

        public  Task<int> DeleteAsync(IVehicleMake item)
        {
            return Repository.DeleteAsync(item);

        }


        public Task<int> InsertAsync(IVehicleMake item)
        {
            return Repository.InsertAsync(item);
        }

        public Task<int> UpdateAsync(IVehicleMake item)
        {
            return Repository.UpdateAsync(item);
            

        }


        public Task<IEnumerable<IVehicleMake>> GetAsync(IPagingDetails pagingDetails)
        {
            return Repository.GetAsync(pagingDetails);
        }

        public Task<IVehicleMake> GetAsync(string ID)
        {
            return Repository.GetAsync(ID);
        }



        public Task<int> DeleteAsync(string id)
        {
            return Repository.DeleteAsync(id);
        }

        public Task<IEnumerable<IVehicleMake>> GetAsync()
        {
            return Repository.GetAsync();
        }
    }
}
