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
            return Repository.DeleteAsync<VehicleModel>(Mapper.Map<VehicleModel>(item));
        }

        public Task<int> DeleteAsync(string id)
        {
            return Repository.DeleteAsync<VehicleModel>(id);
        }

        public async Task<List<IVehicleModel>> GetByMakeAsync(string makeId, PagingDetails pagingDetails)
        {
            return Mapper.Map<List<IVehicleModel>>(
                await Repository.WhereAsync<VehicleModel>()
                     .Where(s => s.MakeId == makeId)
                     .OrderBy(s => s.Name)
                     .Skip(pagingDetails.PageSkip)
                     .Take(pagingDetails.PageSize)
                     .ToListAsync<VehicleModel>());
        }

        public async Task<List<IVehicleModel>> GetAsync(PagingDetails pagingDetails)
        {
            if (pagingDetails.Filter != null)
            {
                return Mapper.Map<List<IVehicleModel>>(
                   await Repository.WhereAsync<VehicleModel>()
                     .Where(s => s.Name.ToLower().Contains(pagingDetails.Filter.ToLower()) || s.Abrv.ToLower().Contains(pagingDetails.Filter.ToLower()))
                     .OrderBy(s => s.Name)
                     .Skip(pagingDetails.PageSkip)
                     .Take(pagingDetails.PageSize)
                     .ToListAsync<VehicleModel>());
            }
            else
            {
                return Mapper.Map<List<IVehicleModel>>(
                   await Repository.WhereAsync<VehicleModel>()
                        .OrderBy(s => s.Name)
                        .Skip(pagingDetails.PageSkip)
                        .Take(pagingDetails.PageSize)
                        .ToListAsync<VehicleModel>());
            }

        }

        public async Task<IVehicleModel> GetAsync(string id)
        {
            return Mapper.Map<IVehicleModel>(await Repository.GetOneAsync<VehicleModel>(id));
        }

        public Task<int> InsertAsync(IVehicleModel item)
        {
            return Repository.InsertAsync<VehicleModel>(Mapper.Map<VehicleModel>(item));
        }

        public Task<int> UpdateAsync(IVehicleModel item)
        {
            return Repository.UpdateAsync<VehicleModel>(Mapper.Map<VehicleModel>(item));
        }
    }
}
