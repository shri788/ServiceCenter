using System.ComponentModel.DataAnnotations;

namespace ServiceCenterReception.Entity
{
    public class ServiceEstimationTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Task { get; set; }

        public string? TaskDescription { get; set; }

        [Required]
        public int EstimatedAmount { get; set; }
    }
}
