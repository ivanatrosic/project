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
        protected IVehicleMakeRepository Repository;
        protected IUnitOfWork UnitOfWork;
        public VehicleMakeService(IVehicleMakeRepository repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public void Delete(VehicleMake item)
        {
            Repository.Delete(item);
            UnitOfWork.Complete();
        }


        public void Insert(VehicleMake item)
        {
            Repository.Insert(item);
            UnitOfWork.Complete();
        }

        public void Update(VehicleMake item)
        {
            Repository.Update(item);
            UnitOfWork.Complete();

        }
        public VehicleMake GetById(int id)
        {
            return Repository.GetById(id);
        }

        public IEnumerable<VehicleMake> GetAll()
        {
            return Repository.GetAll();
        }

        public IEnumerable<VehicleMake> Find(Expression<Func<VehicleMake, bool>> predicate)
        {
            return Repository.Find(predicate);

        }
    }
}
