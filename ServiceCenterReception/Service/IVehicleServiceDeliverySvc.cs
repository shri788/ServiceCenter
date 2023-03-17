using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Service
{
    public interface IVehicleServiceDeliverySvc
    {
        Task<List<VehicleServiceDTO>> getInProcessServices();

        Task<List<VehicleServiceDTO>> getCompletedServicesBetweenDates(DateTime? startDate, DateTime? endDate); 
    }
}
