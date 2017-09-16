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

        public Task<int> DeleteAsync(int id)
        {
            return Repository.DeleteAsync<VehicleModel>(id);
        }

        public async Task<IEnumerable<IVehicleModel>> FilterByMakeAsync(int makeId, PagingDetails pagingDetails)
        {
            return Mapper.Map<IEnumerable<IVehicleModel>>(
                await Repository.WhereAsync<VehicleModel>()
                     .Where(s => s.MakeId == makeId)
                     .OrderBy(s => s.Name)
                     .Skip(pagingDetails.PageSkip)
                     .Take(pagingDetails.PageSize)
                     .ToListAsync<VehicleModel>());
        }

        public async Task<IEnumerable<IVehicleModel>> GetAllAsync(PagingDetails pagingDetails)
        {
            return Mapper.Map<IEnumerable<IVehicleModel>>(
                await Repository.WhereAsync<VehicleModel>()
                     .Skip(pagingDetails.PageSkip)
                    .Take(pagingDetails.PageSize)
                    .ToListAsync<VehicleModel>());

        }

        public async Task<IVehicleModel> GetAsync(int id)
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
