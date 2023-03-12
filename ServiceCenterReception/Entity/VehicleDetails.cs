using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceCenterReception.Entity
{
    public class VehicleDetails
    {
        [Key]
        public long vehicleId { get; set; }

        [Required]
        public string? vehicleType { get; set; }

        [Required]
        public string? vehicleNumber { get; set;}

        [ForeignKey("CustomerProfile")]
        public long customerId { get; set; }
        public virtual CustomerProfile? CustomerProfile { get; set; }
    }
}
