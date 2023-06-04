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

            CreateMap<VehicleServiceDetailReqDTO, VehicleServiceDetail>();

            CreateMap<VehicleDetails, VehicleDetailsDTO>();

            CreateMap<VehicleDetailsDTO, VehicleDetails>();

            //CreateMap<VehicleServiceTaskCompletedList, VehicleServiceTaskCompletedListDTO>();

            CreateMap<VehicleServiceDetail, VehicleServiceDTO>();
        }
    }
}
