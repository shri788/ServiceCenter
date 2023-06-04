using System.ComponentModel.DataAnnotations;

namespace ServiceCenterReception.Entity
{
    public class ServiceTaskMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? TaskName { get; set; }

        [Required]
        public string? TaskDescription { get; set; }

        [Required]
        public int TaskCharges { get; set; }
    }
}
