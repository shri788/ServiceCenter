using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public interface IVehicleServiceTaskRepo
    {
        Task<generalResponseDTO> addTasks(List<VehicleServiceTaskCompletedList> list);

        Task<List<VehicleServiceTaskCompletedList>> vehicleServiceTaskCompletedLists(long serviceId);

        Task<List<VehicleServiceTaskCompletedList>> vehicleServiceTaskCompletedListsByCustId(long customerId);
    }
}
