using AutoMapper;
using Vehicle.DAL;


namespace Vehicle.Models
{
    public  class AutoMaperModels : Profile
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<VehicleMakeDTO, VehicleMake>().ReverseMap();
                config.CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
                config.CreateMap<IVehicleMake, VehicleMakeDTO>().ReverseMap();

                config.CreateMap<VehicleModelDTO, VehicleModel>().ReverseMap();
                config.CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
                config.CreateMap<IVehicleModel, VehicleModelDTO>().ReverseMap();
            });

        }
    }
}
