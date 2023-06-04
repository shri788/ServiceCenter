using ServiceCenterReception.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceCenterReception.DTO
{
    public class VehicleServiceDetailReqDTO
    {
        public long vehicleServiceDetailId { get; set; }

        public long vehicleId { get; set; }

        public virtual VehicleDetailsDTO? VehicleDetails { get; set; }

        public ICollection<ServiceEstimationTask>? ServiceEstimationTasks { get; set; }

        public ICollection<ServiceCompletedTask>? ServiceCompletedTasks { get; set; }

        public VehicleServiceRecieveDelivery? VehicleServiceRecieveDelivery { get; set; }
    }
}
