namespace Vehicle.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

    public partial class VehicleContext : DbContext, IVehicleContext
    {

        public VehicleContext()
            : base("name=VehicleDatabase")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<VehicleMake> VehicleMake { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleMake>()
                .Property(e => e.Abrv)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleMake>()
                .HasMany(e => e.VehicleModel)
                .WithRequired(e => e.VehicleMake)
                .HasForeignKey(e => e.MakeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VehicleModel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleModel>()
                .Property(e => e.Abrv)
                .IsUnicode(false);
        }
    }
}
