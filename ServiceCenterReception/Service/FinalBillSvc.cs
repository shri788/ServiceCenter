using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Repository;

namespace ServiceCenterReception.Service
{
    public class FinalBillSvc: IFinalBillSvc
    {
        private readonly IFinalBillRepo billRepo;

        private readonly IVehicleServiceDetailRepo serviceRepo;

        private readonly IVehicleServiceDeliveryRepo deliveryRepo;

        public FinalBillSvc(IFinalBillRepo billRepo, IVehicleServiceDetailRepo serviceRepo,
            IVehicleServiceDeliveryRepo deliveryRepo)
        {
            this.billRepo = billRepo;
            this.serviceRepo = serviceRepo;
            this.deliveryRepo = deliveryRepo;
        }

        public async Task<generalResponseDTO> generateFinalBill(FinalServiceBill bill)
        {
            generalResponseDTO resObj = new generalResponseDTO();
            if (bill.vehicleServiceDetailId > 0)
            {
                Console.WriteLine(bill.vehicleServiceDetailId + "###");
                var service = await serviceRepo.getVehicleServiceByServiceId(bill.vehicleServiceDetailId);
                if (service != null && service.VehicleServiceRecieveDelivery != null)
                {
                    service.VehicleServiceRecieveDelivery.vehicleDeliveryDate = DateTime.UtcNow;
                    await deliveryRepo.updateDelivery(service.VehicleServiceRecieveDelivery);
                    Console.WriteLine(bill.vehicleServiceDetailId + "$$$$");
                } else
                {
                    resObj.action = "error";
                    resObj.message = "Could not find service related data, please supply accurate data.";
                }
            }
            bill.dateTimeGenerated = DateTime.UtcNow;
            return await billRepo.generateFinalBill(bill);
        }
    }
}
