using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Models
{
    public class VehicleModelDTO : IVehicleModel
    {
        #region Properites
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        #endregion Properites
    }
}
