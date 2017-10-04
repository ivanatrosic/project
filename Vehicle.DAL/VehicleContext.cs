namespace Vehicle.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;
    using Vehicle.DAL.Mapping;

    public partial class VehicleContext : DbContext, IVehicleContext
    {

        public VehicleContext()
            : base("name=VehicleDatabase")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public static VehicleContext Create()
        {
            return new VehicleContext();
        }

        public virtual DbSet<VehicleMake> VehicleMake { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VehicleModelMap());
            modelBuilder.Configurations.Add(new VehicleMakeMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
