using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.DTO
{
    public class CustomerVehicleServiceDTO
    {
        [Key]
        public long customerId { get; set; }

        [Required]
        public string? gender { get; set; }

        [Required(ErrorMessage = "Customer Name Is Mandatory")]
        public string? customerName { get; set; }

        [Required]
        [Range(1, 99999999999, ErrorMessage = "Mobile Number Is Mandatory & Length must be 10")]
        public long mobileNumber { get; set; }

        public string? address { get; set; }

        public long addressPinCode { get; set; }

        [EmailAddress]
        public string? email { get; set; }

        [DefaultValue("0001-01-01T00:00:00.000Z")]
        public DateTime DOB { get; set; }

        [DefaultValue("0001-01-01T00:00:00.000Z")]
        public DateTime? DOM { get; set; }

        public DateTime? lastServiceDate { get; set; }

        public int dueInMonths { get; set; }

        public virtual VehicleServiceDetailReqDTO? VehicleServiceDetail { get; set; }
    }
}
