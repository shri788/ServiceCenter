using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public interface IVehicleServiceTaskRepo
    {
        Task<generalResponseDTO> addTasks(VehicleServiceTaskCompletedList list)
    }
}
