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

namespace Vehicle.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected IRepository Repository { get; set; }
        public VehicleMakeRepository(IRepository repository)
        {
            Repository = repository;
        }


        public async Task<IEnumerable<VehicleMake>> GetAllAsync()
        {
            return await Repository.WhereAsync<VehicleMake>().ToListAsync();
        }

        public async Task<IEnumerable<VehicleMake>> FilterAsync(string filter)
        {
      
                return await Repository.FindAsync<VehicleMake>(s => s.Name.Contains(filter) || s.Abrv.Contains(filter));
 
        }

        //public async Task<IEnumerable<VehicleMake>> SortAsync()
        //{
        //    return await Repository.OrderAsync<VehicleMake>(s => s.Name);
        //}

        public Task<int> InsertAsync(VehicleMake item)
        {
            return Repository.InsertAsync(item);
        }

        public Task<int> UpdateAsync(VehicleMake item)
        {
            return Repository.InsertAsync<VehicleMake>(item);
        }

        public Task<int> DeleteAsync(VehicleMake item)
        {
            return Repository.DeleteAsync<VehicleMake>(item);
        }

        public Task<int> DeleteAsync(int id)
        { 
            return Repository.DeleteAsync<VehicleMake>(id);
        }

        public Task<VehicleMake> GetOneAsync(int id) 
        {
            return Repository.GetOneAsync<VehicleMake>(id);
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

