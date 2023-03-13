using ServiceCenterReception.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceCenterReception.DTO
{
    public class VehicleServiceTaskCompletedListDTO
    {
        public long taskServiceId { get; set; }

        public string? taskServiceName { get; set; }

        public long taskServiceCharges { get; set; }

        public string? remarks { get; set; }
    }
}
