using ServiceCenterReception.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceCenterReception.DTO
{
    public class VehicleServiceDetailDTO
    {
        public long vehicleServiceDetailId { get; set; }

        [ForeignKey("VehicleDetails")]
        public long vehicleId { get; set; }

        public VehicleDetailsDTO? VehicleDetails { get; set; }

        public VehicleServiceRecieveDelivery? VehicleServiceRecieveDelivery { get; set; }

        public List<VehicleServiceTaskCompletedListDTO>? VehicleServiceTaskCompletedLists { get; set; }
    }
}
