using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.Repository;

namespace Vehicle.Repository
{
    public class VehicleMakeRepository : Repository<VehicleMake>, IVehicleMakeRepository
    {

        public VehicleMakeRepository(DbContext context) : base(context)
        {

        }

        public VehicleMake GetById(int id)
        {
            return Context.Set<VehicleMake>().Find(id);
        }

        public IEnumerable<VehicleMake> GetAll()
        {
            return Context.Set<VehicleMake>().ToList();
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

