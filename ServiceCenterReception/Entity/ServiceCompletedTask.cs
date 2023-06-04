using System.ComponentModel.DataAnnotations;

namespace ServiceCenterReception.Entity
{
    public class ServiceCompletedTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Task { get; set; }

        public string? TaskDescription { get; set; }

        [Required]
        public int TaskCharges { get; set; }
    }
}
