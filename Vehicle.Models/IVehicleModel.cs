using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Models
{
    public interface IVehicleModel
    {
        string Id { get; set; }
        string MakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }

    }
}
