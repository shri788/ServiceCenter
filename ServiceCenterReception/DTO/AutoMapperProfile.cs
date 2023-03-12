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

        }
    }
}
