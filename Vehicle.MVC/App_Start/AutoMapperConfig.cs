using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicle.Models;
using AutoMapper;
using Vehicle.MVC.Models;

namespace Vehicle.MVC.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<VehicleMakeData, VehicleMakeDTO>().ReverseMap();
                config.CreateMap<VehicleMakeData, IVehicleMake>().ReverseMap();

                config.CreateMap<VehicleModelData, VehicleModelDTO>().ReverseMap();
                config.CreateMap<VehicleModelData, IVehicleModel>().ReverseMap();
            });

        }
    }
}