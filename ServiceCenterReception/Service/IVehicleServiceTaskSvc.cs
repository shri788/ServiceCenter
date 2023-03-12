using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Service
{
    public interface IVehicleServiceTaskSvc
    {
        Task<generalResponseDTO> addTasks(VehicleServiceTaskCompletedList list);
    }
}
