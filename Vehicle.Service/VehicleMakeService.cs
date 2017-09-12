using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Repository;
using Vehicle.DAL;
using System.Linq.Expressions;

namespace Vehicle.Service
{
    public class VehicleMakeService :IVehicleMakeService
    {
        protected IVehicleMakeRepository Repository { get; private set; }

        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            Repository = repository;
  
        }

        public  Task<int> DeleteAsync(VehicleMake item)
        {
            return Repository.DeleteAsync(item);

        }


        public Task<int> InsertAsync(VehicleMake item)
        {
            return Repository.InsertAsync(item);
        }

        public Task<int> UpdateAsync(VehicleMake item)
        {
            return Repository.UpdateAsync(item);
            

        }


        public Task<IEnumerable<VehicleMake>> GetAllAsync()
        {
            return Repository.GetAllAsync();
        }

        //public Task<IEnumerable<VehicleMake>> FindAsync(Expression<Func<VehicleMake, bool>> predicate)
        //{
        //    return Repository.FindAsync(predicate);

        //}
        public Task<VehicleMake> GetOneAsync(int ID)
        {
            return Repository.GetOneAsync(ID);
        }


        public Task<IEnumerable<VehicleMake>> FilterAsync(string filter)
        {
            return Repository.FilterAsync(filter);
        }

        //public Task<IEnumerable<VehicleMake>> SortAsync()
        //{
        //    return Repository.SortAsync();
        //}

        public Task<int> DeleteAsync(int id)
        {
            return Repository.DeleteAsync(id);
        }
    }
}
