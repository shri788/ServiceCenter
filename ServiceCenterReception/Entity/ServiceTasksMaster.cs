using System.ComponentModel.DataAnnotations;

namespace ServiceCenterReception.Entity
{
    public class ServiceTasksMaster
    {
        [Key]
        public int taskId { get; set; }

        [Required]
        public string? taskServiceName { get; set; }

        [Required]
        public long chargesInRuppes { get; set; }

        public string? remarks { get; set; }

    }
}
