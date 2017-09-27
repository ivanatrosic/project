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
            return Repository.DeleteAsync<VehicleModel>(Mapper.Map<VehicleModel>(item));
        }

        public Task<int> DeleteAsync(string id)
        {
            return Repository.DeleteAsync<VehicleModel>(id);
        }

        public async Task<IEnumerable<IVehicleModel>> GetByMakeAsync(string makeId, IPagingDetails pagingDetails)
        {
            var x = Mapper.Map<IEnumerable<IVehicleModel>>(
                await Repository.WhereAsync<VehicleModel>()
                     .Where(s => s.MakeId == makeId)
                     .OrderBy(s => s.Name)
                     .ToListAsync<VehicleModel>());
            return x.ToPagedList(pagingDetails.PageNumber, pagingDetails.PageSize);
        }

        public async Task<IEnumerable<IVehicleModel>> GetAsync(IPagingDetails pagingDetails)
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
