using ServiceCenterReception.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceCenterReception.DTO
{
    public class VehicleDetailsDTO
    {
        public long vehicleId { get; set; }

        public string? vehicleType { get; set; }

        public string? vehicleNumber { get; set; }

        public long customerId { get; set; }
    }
}
