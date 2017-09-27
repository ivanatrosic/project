using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.Repository;
using AutoMapper;
using Vehicle.Models;
using Vehicle.Paging;
using PagedList;

namespace Vehicle.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected IRepository Repository { get; set; }
        public VehicleMakeRepository(IRepository repository)
        {
            Repository = repository;
        }


        public async Task<IEnumerable<IVehicleMake>> GetAsync(IPagingDetails pagingDetails)
        {
 
            if (pagingDetails.Filter != null)
            {
               
                 var x = Mapper.Map<IEnumerable<IVehicleMake>>(
                    await Repository.WhereAsync<VehicleMake>()
                      .Where(s => s.Name.Contains(pagingDetails.Filter) ||  s.Abrv.Contains(pagingDetails.Filter))
                      .OrderBy(s => s.Name)
                      //.Skip(pagingDetails.PageSkip)
                      //.Take(pagingDetails.PageSize)
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

        public async Task<IVehicleMake> GetAsync(string id)
        {
            return Mapper.Map<IVehicleMake>(await Repository.GetOneAsync<VehicleMake>(id));
        }


        public Task<int> InsertAsync(IVehicleMake item)
        {
            return Repository.InsertAsync<VehicleMake>(Mapper.Map<VehicleMake>(item));
        }


        public Task<int> UpdateAsync(IVehicleMake item)
        {
            return Repository.UpdateAsync <VehicleMake>(Mapper.Map<VehicleMake>(item));
        }

        public Task<int> DeleteAsync(IVehicleMake item)
        {
            return Repository.DeleteAsync<VehicleMake>(Mapper.Map<VehicleMake>(item));
        }

        public Task<int> DeleteAsync(string id)
        { 
            return Repository.DeleteAsync<VehicleMake>(id);
        }

 





        //    public void InsertVehicleMake(VehicleMake vehicleMake)
        //    {
        //        context.VehicleMake.Add(vehicleMake);
        //    }

        //    public void DeleteVehicleMake(int id)
        //    {
        //        VehicleMake vehicleMake = context.VehicleMake.Find(id);
        //        context.VehicleMake.Remove(vehicleMake);
        //    }

        //    public void UpdateVehicleMake(VehicleMake vehicleMake)
        //    {
        //        context.Entry(vehicleMake).State = EntityState.Modified;
        //    }

        //    public void Save()
        //    {
        //        context.SaveChanges();
        //    }

        //    public void Dispose()
        //    {
        //        context.Dispose();
        //    }
    }
}

