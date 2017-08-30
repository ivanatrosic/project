namespace Vehicle.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VehicleContext : DbContext
    {
        public VehicleContext()
            : base("name=VehicleDatabase")
        {
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
