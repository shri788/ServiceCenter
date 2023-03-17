using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Repository;

namespace ServiceCenterReception.Service
{
    public class VehicleServiceDeliverySvc: IVehicleServiceDeliverySvc
    {
        private readonly IVehicleServiceDeliveryRepo deliveryRepo;

        public VehicleServiceDeliverySvc(IVehicleServiceDeliveryRepo deliveryRepo)
        {
            this.deliveryRepo = deliveryRepo;
        }

        public async Task<List<VehicleServiceDTO>> getInProcessServices()
        {
            return await deliveryRepo.getInProcessServices();
        }

        public async Task<List<VehicleServiceDTO>> getCompletedServicesBetweenDates(DateTime? startDate, DateTime? endDate)
        {
            return await deliveryRepo.getCompletedServicesBetweenDates(startDate, endDate);
        }
    }
}
