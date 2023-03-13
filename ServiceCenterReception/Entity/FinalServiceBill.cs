using System.ComponentModel.DataAnnotations;

namespace ServiceCenterReception.Entity
{
    public class FinalServiceBill
    {
        [Key]
        public long finalServiceBillId { get; set; }

        [Required]
        public long customerId { get; set; }

        [Required]
        public long vehicleServiceDetailId { get; set; }

        [Required]
        public long totalAmount { get; set; }

        public long discountPercentage { get; set; }

        public long discountAmount { get; set; }

        [Required]
        public long amountPaid { get; set; }

        public  DateTime dateTimeGenerated { get; set; }
    }
}
