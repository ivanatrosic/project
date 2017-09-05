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
    public class VehicleMakeRepository : Repository, IVehicleMakeRepository
    {

        public VehicleMakeRepository(DbContext context) : base(context)
        {

        }


        public async Task<IEnumerable<VehicleMake>> GetAllAsync()
        {
            return await Context.Set<VehicleMake>().ToListAsync();
        }

        public async Task<IEnumerable<VehicleMake>> FilterAsync(string filter)
        {
      
                return await Context.Set<VehicleMake>().Where(s => s.Name.Contains(filter) || s.Abrv.Contains(filter)).ToListAsync();
 
        }

        public async Task<IEnumerable<VehicleMake>> SortAsync()
        {
            return await Context.Set<VehicleMake>().OrderBy(x => x.Name).ToListAsync();
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

