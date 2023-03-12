using ServiceCenterReception.Entity;

namespace ServiceCenterReception.DTO
{
    public class ServiceDTO
    {
        public CustomerProfile? CustomerProfile { get; set; }

        public List<VehicleServiceDetailDTO>? vehicleServiceDetails { get; set; }
    }
}
