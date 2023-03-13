using AutoMapper;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.DTO
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerVehicleServiceDTO, CustomerProfile>();

            CreateMap<CustomerProfile, CustomerVehicleServiceDTO>();

            CreateMap<VehicleServiceDetail, VehicleServiceDetailDTO>();

            CreateMap<VehicleDetails, VehicleDetailsDTO>();

            CreateMap<VehicleServiceTaskCompletedList, VehicleServiceTaskCompletedListDTO>();
        }
    }
}
