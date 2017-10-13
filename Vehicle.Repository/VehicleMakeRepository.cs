using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using AutoMapper;
using Vehicle.Models;
using Vehicle.Common;
using PagedList;

namespace Vehicle.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        #region Properties
        protected IRepository Repository { get; set; }
        #endregion Properties


        #region Constructors
        public VehicleMakeRepository(IRepository repository)
        {
            Repository = repository;
        }
        #endregion Constructors


        #region Methods
        public async Task<IEnumerable<IVehicleMake>> GetAsync(IPagingDetails pagingDetails)
        {
            try
            {
                if (pagingDetails.Filter != null)
            {
               
                 var x = Mapper.Map<IEnumerable<IVehicleMake>>(
                    await Repository.WhereAsync<VehicleMake>()
                      .Where(s => s.Name.Contains(pagingDetails.Filter) ||  s.Abrv.Contains(pagingDetails.Filter))
                      .OrderBy(s => s.Name)
                      .ToListAsync<VehicleMake>());
                return x.ToPagedList(pagingDetails.PageNumber, pagingDetails.PageSize);

            }
            else
            {
                var x = Mapper.Map<IEnumerable<IVehicleMake>>(
                   await Repository.WhereAsync<VehicleMake>()
                        .OrderBy(s => s.Name)
                        .ToListAsync<VehicleMake>());
                return x.ToPagedList(pagingDetails.PageNumber, pagingDetails.PageSize);
            }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IVehicleMake> GetAsync(Guid? id)
        {
            try
            {
                return Mapper.Map<IVehicleMake>(await Repository.GetOneAsync<VehicleMake>(id));
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
                return Repository.InsertAsync<VehicleMake>(Mapper.Map<VehicleMake>(item));
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
                return Repository.UpdateAsync<VehicleMake>(Mapper.Map<VehicleMake>(item));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> DeleteAsync(IVehicleMake item)
        {
            try
            {
                return Repository.DeleteAsync<VehicleMake>(Mapper.Map<VehicleMake>(item));
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
                return Repository.DeleteAsync<VehicleMake>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<IVehicleMake>> GetAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<IVehicleMake>>(
                       await Repository.WhereAsync<VehicleMake>()
                         .OrderBy(s => s.Name)
                         .ToListAsync<VehicleMake>());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Methods
    }
}

