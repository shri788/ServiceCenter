using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public interface IVehicleServiceDeliveryRepo
    {
        Task<VehicleServiceRecieveDelivery> getDeliveryById(long deliveryId);

        Task<VehicleServiceRecieveDelivery> updateDelivery(VehicleServiceRecieveDelivery delivery);

        Task<List<VehicleServiceDTO>> getInProcessServices();

        Task<List<VehicleServiceDTO>> getCompletedServicesBetweenDates(DateTime? startDate, DateTime? endDate);
    }
}
