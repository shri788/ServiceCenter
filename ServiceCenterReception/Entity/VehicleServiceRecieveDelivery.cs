using System.ComponentModel.DataAnnotations;

namespace ServiceCenterReception.Entity
{
    public class VehicleServiceRecieveDelivery
    {
        [Key]
        public long VehicleServiceRecieveDeliveryId { get; set; }

        public DateTime vehicleReceiveDate { get; set; }

        public DateTime vehicleDeliveryDate { get; set; }
    }
}
