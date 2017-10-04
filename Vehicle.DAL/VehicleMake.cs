namespace Vehicle.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleMake")]
    public partial class VehicleMake
    {
      
        public VehicleMake()
        {
            VehicleModel = new HashSet<VehicleModel>();
        }

        #region Properites
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public virtual ICollection<VehicleModel> VehicleModel { get; set; }
        #endregion Properites
    }
}
