using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;


namespace Vehicle.Models
{
    public  class AutoMaperModels : Profile
    {
        public AutoMaperModels()
        {
            
            CreateMap<VehicleMakeDTO, VehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();

            CreateMap<VehicleModelDTO, VehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
        }
    }
}
