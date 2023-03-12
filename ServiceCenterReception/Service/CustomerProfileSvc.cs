using AutoMapper;
using ServiceCenterReception.Data;
using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Repository;

namespace ServiceCenterReception.Service
{
    public class CustomerProfileSvc: ICustomerProfileSvc
    {
        private readonly ICustomerProfileRepo customerRepo;

        private readonly IVehicleDetailsRepo vehicleDetailsRepo;

        private readonly IVehicleServiceDetailRepo serviceDetailRepo;

        private readonly IMapper mapper;

        public CustomerProfileSvc(ICustomerProfileRepo customerRepo, IMapper mapper,
            IVehicleDetailsRepo vehicleDetailsRepo, IVehicleServiceDetailRepo serviceDetailRepo)
        {
            this.customerRepo = customerRepo;
            this.mapper = mapper;
            this.vehicleDetailsRepo = vehicleDetailsRepo;
            this.serviceDetailRepo = serviceDetailRepo;
        }

        public async Task<generalResponseDTO> addCustomer(CustomerVehicleServiceDTO customer)
        {
            generalResponseDTO resObj = new generalResponseDTO();
            var vehicleDetails = customer.VehicleServiceDetail?.VehicleDetails;
            var vehicleServiceDetail = customer.VehicleServiceDetail;
            var customerProfile = mapper.Map<CustomerProfile>(customer);
            var customerCreatedUpdated = await customerRepo.addCustomer(customerProfile);
            long vehicleId = 0;
            
            if (vehicleDetails != null && customerCreatedUpdated != null && customerCreatedUpdated.customerId != 0)
            {
                if(vehicleDetails.vehicleId == 0 || vehicleDetails.vehicleId < 0)
                {
                    vehicleDetails.customerId = customerCreatedUpdated.customerId;
                    await vehicleDetailsRepo.addVehicle(vehicleDetails);
                    vehicleId = vehicleDetails.vehicleId;
                } else
                {
                    var vehicle = await vehicleDetailsRepo.getVehicle(vehicleDetails.vehicleId);
                    if (vehicle != null)
                        vehicleId = vehicle.vehicleId;
                }
            }
            if (vehicleServiceDetail != null && customerCreatedUpdated != null && customerCreatedUpdated.customerId != 0)
            {
                vehicleServiceDetail.customerId = customerCreatedUpdated.customerId;
                vehicleServiceDetail.vehicleId = vehicleId;
                vehicleServiceDetail.VehicleServiceRecieveDelivery.vehicleReceiveDate = DateTime.UtcNow;
                await serviceDetailRepo.addServiceData(vehicleServiceDetail);
            }
            resObj.action = "success";
            resObj.message = "Customer data & service data created successfully.";
            return resObj;
        }

        public async Task<CustomerVehicleServiceDTO> getCustomerByMobilrNo(long mobileNo)
        {
            var result = await customerRepo.getCustomerByMobilrNo(mobileNo);
            return result;
        }
    }
}
