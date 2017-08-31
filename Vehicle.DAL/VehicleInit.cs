using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Vehicle.DAL
{
    public class VehicleInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var students = new List<VehicleMake>
            {
            new VehicleMake{Id=1,Name="Volkswagen",Abrv="VW"},
            new VehicleMake{Id=2,Name="BMW",Abrv="BMW"},
            new VehicleMake{Id=3,Name="Audi",Abrv="A"},

            };

            students.ForEach(s => context.VehicleMake.Add(s));
            context.SaveChanges();
            var courses = new List<VehicleModel>
            {
            new VehicleModel{Id=1, MakeId=1, Name="Passat", Abrv="VW Passat"},
            new VehicleModel{Id=2, MakeId=1, Name="Golf 5", Abrv="VW Golf 5"},
            new VehicleModel{Id=3, MakeId=1, Name="Golf 7", Abrv="VW Golf 7"},
            new VehicleModel{Id=4, MakeId=2, Name="Q5", Abrv="BMW Q5"},
            new VehicleModel{Id=5, MakeId=3, Name="Q5", Abrv="Audi Q5"},
            };
            courses.ForEach(s => context.VehicleModel.Add(s));
            context.SaveChanges();
         
        }
    }
}
