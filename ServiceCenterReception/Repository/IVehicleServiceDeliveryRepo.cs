using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public interface IVehicleServiceDeliveryRepo
    {
        Task<VehicleServiceRecieveDelivery> getDeliveryById(long deliveryId);
        Task<VehicleServiceRecieveDelivery> updateDelivery(VehicleServiceRecieveDelivery delivery);
    }
}
