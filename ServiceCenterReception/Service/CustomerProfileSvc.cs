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

        private readonly IVehicleServiceTaskRepo taskRepo;

        private readonly IMapper mapper;

        public CustomerProfileSvc(ICustomerProfileRepo customerRepo, IMapper mapper,
            IVehicleDetailsRepo vehicleDetailsRepo, IVehicleServiceDetailRepo serviceDetailRepo,
            IVehicleServiceTaskRepo taskRepo)
        {
            this.customerRepo = customerRepo;
            this.mapper = mapper;
            this.vehicleDetailsRepo = vehicleDetailsRepo;
            this.serviceDetailRepo = serviceDetailRepo;
            this.taskRepo = taskRepo;
        }

        public async Task<generalResponseDTO> addCustomer(CustomerVehicleServiceDTO customer)
        {
            generalResponseDTO resObj = new generalResponseDTO();
            var vehicleDetails = customer.VehicleServiceDetail?.VehicleDetails;
            var vehicleServiceDetail = customer.VehicleServiceDetail;
            long vehicleId = 0;
            var customerProfile = mapper.Map<CustomerProfile>(customer);
            var customerCreatedUpdated = new CustomerProfile();
            if(customerProfile.customerId > 0)
            {
                customerCreatedUpdated = await customerRepo.updateCustomer(customerProfile);
            } else
            {
                customerCreatedUpdated = await customerRepo.addCustomer(customerProfile);
            }
            
            if (vehicleDetails != null && customerCreatedUpdated != null && customerCreatedUpdated.customerId != 0)
            {
                if(vehicleDetails.vehicleId > 0)
                {
                    var vehicle = await vehicleDetailsRepo.getVehicle(vehicleDetails.vehicleId);
                    if (vehicle != null)
                    {
                        vehicleId = vehicle.vehicleId;
                    } else
                    {
                        resObj.action = "error";
                        resObj.message = "Wrong vehicle Id found, please check again.";
                    }
                } else
                {
                    vehicleDetails.customerId = customerCreatedUpdated.customerId;
                    await vehicleDetailsRepo.addVehicle(vehicleDetails);
                    vehicleId = vehicleDetails.vehicleId;
                }
            }
            if (vehicleServiceDetail != null && customerCreatedUpdated != null && customerCreatedUpdated.customerId != 0)
            {
                vehicleServiceDetail.customerId = customerCreatedUpdated.customerId;
                vehicleServiceDetail.vehicleId = vehicleId;
                vehicleServiceDetail.VehicleServiceRecieveDelivery.vehicleReceiveDate = DateTime.UtcNow;
                DateTime dateTime = new DateTime(1970, 1, 1, 5, 30, 0);
                DateTime utcDateTime = dateTime.ToUniversalTime();
                vehicleServiceDetail.VehicleServiceRecieveDelivery.vehicleDeliveryDate = utcDateTime;
                await serviceDetailRepo.addServiceData(vehicleServiceDetail);
            }
            resObj.action = "success";
            resObj.message = "Customer data & service data created successfully.";
            return resObj;
        }

        public async Task<ServiceDTO> getCustomerByMobileNo(long mobileNo)
        {
            CustomerProfile customerProfile = await customerRepo.getCustomerByMobileNo(mobileNo);
            ServiceDTO result = new ServiceDTO();
            result.CustomerProfile = customerProfile;

            if (result.CustomerProfile != null)
            {
                long customerId = result.CustomerProfile.customerId;
                var serviceDetails = await serviceDetailRepo.getVehicleServiceByCustomerId(customerId);
                result.vehicleServiceDetails = mapper.Map<List<VehicleServiceDetailDTO>>(serviceDetails);
            }
            
            if (result.CustomerProfile != null && result.vehicleServiceDetails != null)
            {
                var taskList = await taskRepo.vehicleServiceTaskCompletedListsByCustId(result.CustomerProfile.customerId);
                result.vehicleServiceDetails.ForEach(async service =>
                {
                    var taskListForService = taskList.Where(x => x.vehicleServiceDetailId == service.vehicleServiceDetailId).ToList();
                    service.VehicleServiceTaskCompletedLists = mapper.Map<List<VehicleServiceTaskCompletedListDTO>>(taskListForService);
                });
            }
            
            return result;
        }
    }
}
