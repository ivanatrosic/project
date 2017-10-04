using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Models;
using Vehicle.Paging;
using AutoMapper;
using Vehicle.DAL;
using System.Data.Entity;
using PagedList;

namespace Vehicle.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected IRepository Repository { get; set; }


        public VehicleModelRepository(IRepository repository)
        {
            Repository = repository;
        }



        public Task<int> DeleteAsync(IVehicleModel item)
        {
            try
            {
                return Repository.DeleteAsync<VehicleModel>(Mapper.Map<VehicleModel>(item));
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
                return Repository.DeleteAsync<VehicleModel>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<IVehicleModel>> GetByMakeAsync(Guid? makeId, IPagingDetails pagingDetails)
        {
            try
            {
                var x = Mapper.Map<IEnumerable<IVehicleModel>>(
                    await Repository.WhereAsync<VehicleModel>()
                         .Where(s => s.MakeId == makeId)
                         .OrderBy(s => s.Name)
                         .ToListAsync<VehicleModel>());
                return x.ToPagedList(pagingDetails.PageNumber, pagingDetails.PageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<IVehicleModel>> GetAsync(IPagingDetails pagingDetails)
        {
            try
            {
                if (pagingDetails.Filter != null)
            {
                var x = Mapper.Map<IEnumerable<IVehicleModel>>(
                   await Repository.WhereAsync<VehicleModel>()
                     .Where(s => s.Name.Contains(pagingDetails.Filter) || s.Abrv.Contains(pagingDetails.Filter))
                     .OrderBy(s => s.Name)
                     .ToListAsync<VehicleModel>());
                return x.ToPagedList(pagingDetails.PageNumber, pagingDetails.PageSize);
            }
            else
            {
                var x = Mapper.Map<IEnumerable<IVehicleModel>>(
                   await Repository.WhereAsync<VehicleModel>()
                        .OrderBy(s => s.Name)
                        .ToListAsync<VehicleModel>());
                return x.ToPagedList(pagingDetails.PageNumber, pagingDetails.PageSize);
            }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<IVehicleModel> GetAsync(Guid? id)
        {
            try
            { 
            return Mapper.Map<IVehicleModel>(await Repository.GetOneAsync<VehicleModel>(id));
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
            return Repository.InsertAsync<VehicleModel>(Mapper.Map<VehicleModel>(item));
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
            return Repository.UpdateAsync<VehicleModel>(Mapper.Map<VehicleModel>(item));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
