using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceCenterReception.Entity
{
    public class VehicleServiceTaskCompletedList
    {
        [Key]
        public long taskServiceId { get; set; }

        [Required]
        public string? taskServiceName { get; set; }

        [Required]
        public long taskServiceCharges { get; set; }

        public long customerId { get; set; }

        public  string? remarks { get; set; }

        [ForeignKey("VehicleServiceDetail")]
        public long vehicleServiceDetailId { get; set; }

        public virtual VehicleServiceDetail? VehicleServiceDetail { get; set; }
    }
}
