using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Models
{
    public class VehicleMakeDTO : IVehicleMake
    {
        #region Properites
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        #endregion Properites
    }
}
