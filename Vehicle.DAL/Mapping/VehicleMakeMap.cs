using System.Data.Entity.ModelConfiguration;

namespace Vehicle.DAL.Mapping
{
    public class VehicleMakeMap : EntityTypeConfiguration<VehicleMake>
    {
        public VehicleMakeMap()
        {
            //Primary key
            this.HasKey(t => t.Id);

            //Table Mapping
            this.ToTable("VehicleMake");
            this.Property(t => t.Name).HasColumnName("Name").HasMaxLength(50); 
            this.Property(t => t.Abrv).HasColumnName("Abrv").HasMaxLength(50);

            // Relationships
            this.HasMany(e => e.VehicleModel)
                .WithRequired(e => e.VehicleMake)
                .HasForeignKey(e => e.MakeId)
                .WillCascadeOnDelete(false);
        }
    }
}
