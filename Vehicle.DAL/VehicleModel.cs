namespace Vehicle.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleModel")]
    public partial class VehicleModel
    {
        #region Properites
        public Guid Id { get; set; }

        public Guid MakeId { get; set; }


        public string Name { get; set; }


        public string Abrv { get; set; }



        public virtual VehicleMake VehicleMake { get; set; }
        #endregion Properites
    }
}
