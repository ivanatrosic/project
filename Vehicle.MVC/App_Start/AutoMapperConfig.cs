using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicle.Models;
using AutoMapper;
using Vehicle.MVC.Models;
using Vehicle.DAL;

namespace Vehicle.MVC.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<VehicleMakeDTO, VehicleMake>().ReverseMap();
                config.CreateMap<IVehicleMake, VehicleMake>().ReverseMap();

                config.CreateMap<VehicleModelDTO, VehicleModel>().ReverseMap();
                config.CreateMap<IVehicleModel, VehicleModel>().ReverseMap();

                config.CreateMap<VehicleMakeData, VehicleMakeDTO>().ReverseMap();
                config.CreateMap<VehicleMakeData, IVehicleMake>().ReverseMap();

                config.CreateMap<VehicleModelData, VehicleModelDTO>().ReverseMap();
                config.CreateMap<VehicleModelData, IVehicleModel>().ReverseMap();
            });

        }
    }
}