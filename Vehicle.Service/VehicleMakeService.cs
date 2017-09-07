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
    class VehicleMakeService :IVehicleMakeService
    {
        protected IVehicleMakeRepository Repository { get; private set; }
        protected IUnitOfWork UnitOfWork;
        public VehicleMakeService(IVehicleMakeRepository repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
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
            return Repository.GetOneAsync<VehicleMake>(ID);
        }


        public Task<IEnumerable<VehicleMake>> FilterAsync(string filter)
        {
            return Repository.FilterAsync(filter);
        }

        public Task<IEnumerable<VehicleMake>> SortAsync()
        {
            return Repository.SortAsync();
        }


    }
}
