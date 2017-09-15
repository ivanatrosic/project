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


        public Task<IEnumerable<IVehicleMake>> GetAllAsync(PagingDetails pagingDetails)
        {
            return Repository.GetAllAsync(pagingDetails);
        }

        //public Task<IEnumerable<VehicleMake>> FindAsync(Expression<Func<VehicleMake, bool>> predicate)
        //{
        //    return Repository.FindAsync(predicate);

        //}
        public Task<IVehicleMake> GetAsync(int ID)
        {
            return Repository.GetAsync(ID);
        }


        public Task<IEnumerable<IVehicleMake>> FilterAsync(string filter, PagingDetails pagingDetails)
        {
            return Repository.FilterAsync(filter, pagingDetails);
        }

        public Task<IEnumerable<IVehicleMake>> SortAsync()
        {
            return Repository.SortAsync();
        }

        public Task<int> DeleteAsync(int id)
        {
            return Repository.DeleteAsync(id);
        }
    }
}
