using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Repository;
using Vehicle.Common;
using System.Linq.Expressions;
using Vehicle.Models;

namespace Vehicle.Service
{
    public class VehicleMakeService :IVehicleMakeService
    {
        #region Properties
        protected IVehicleMakeRepository Repository { get; private set; }
        #endregion Properties

        #region Constructors
        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            Repository = repository;
  
        }
        #endregion Constructors


        #region Methods
        public Task<int> DeleteAsync(IVehicleMake item)
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


        public Task<int> InsertAsync(IVehicleMake item)
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

        public Task<int> UpdateAsync(IVehicleMake item)
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


        public Task<IEnumerable<IVehicleMake>> GetAsync(IPagingDetails pagingDetails)
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

        public Task<IVehicleMake> GetAsync(Guid? ID)
        {
            try
            {
                return Repository.GetAsync(ID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public Task<int> DeleteAsync(Guid? id)
        {
            try
            {
                return Repository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<IEnumerable<IVehicleMake>> GetAsync()
        {
            try
            {
                return Repository.GetAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Methods
    }
}
