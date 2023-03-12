
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceCenterReception.Entity
{
    public class VehicleServiceDetail
    {
        public long vehicleServiceDetailId { get; set; }

        [ForeignKey("VehicleDetails")]
        public long vehicleId { get; set; }

        public virtual VehicleDetails? VehicleDetails { get; set; }

        public VehicleServiceRecieveDelivery? VehicleServiceRecieveDelivery { get; set; }

        [ForeignKey("CustomerProfile")]
        public long customerId { get; set; }
        public virtual CustomerProfile? CustomerProfile { get; set; }
    }
}
