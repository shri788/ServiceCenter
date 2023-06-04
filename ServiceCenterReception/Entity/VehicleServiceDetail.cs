
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceCenterReception.Entity
{
    public class VehicleServiceDetail
    {
        public long vehicleServiceDetailId { get; set; }

        [Required]
        public long vehicleId { get; set; }

        public VehicleServiceRecieveDelivery? VehicleServiceRecieveDelivery { get; set; }

        public ICollection<ServiceEstimationTask>? ServiceEstimationTasks { get; set; }

        public ICollection<ServiceCompletedTask>? ServiceCompletedTasks { get; set; }

        [Required]
        [ForeignKey("CustomerProfile")]
        public long customerId { get; set; }
        public CustomerProfile? CustomerProfile { get; set; }
    }
}
