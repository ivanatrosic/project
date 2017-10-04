using System.Data.Entity.ModelConfiguration;

namespace Vehicle.DAL.Mapping
{
    public class VehicleModelMap: EntityTypeConfiguration<VehicleModel>
    {
        public VehicleModelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            //Table Mapping
            this.ToTable("VehicleModel");
            this.Property(t => t.MakeId).HasColumnName("MakeId");
            this.Property(t => t.Name).HasColumnName("Name").HasMaxLength(50);
            this.Property(t => t.Abrv).HasColumnName("Abrv").HasMaxLength(50);

        }
    }
}
