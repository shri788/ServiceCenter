using AutoMapper;
using ServiceCenterReception.Data;
using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Repository;
using System.Text.Json;

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
            try
            {
                long vehicleId = 0;
                var vehicleDetails = new VehicleDetailsDTO();
                if (customer.VehicleServiceDetail != null && customer.VehicleServiceDetail.vehicleId > 0)
                    vehicleId = customer.VehicleServiceDetail.vehicleId;
                if (customer.VehicleServiceDetail != null && vehicleId == 0)
                    vehicleDetails = customer.VehicleServiceDetail.VehicleDetails;
                var vehicleServiceDetail = customer.VehicleServiceDetail;

                var customerProfile = mapper.Map<CustomerProfile>(customer);
                var customerCreatedUpdated = new CustomerProfile();

                if (customerProfile.customerId > 0)
                {
                    var existingCustomer = await customerRepo.getCustomerByCustomerId(customerProfile.customerId);
                    if (existingCustomer != null)
                    {
                        customerProfile.mobileNumber = existingCustomer.mobileNumber;
                    }
                    customerCreatedUpdated = await customerRepo.updateCustomer(customerProfile);
                }
                else
                {
                    customerCreatedUpdated = await customerRepo.addCustomer(customerProfile);
                }

                if (vehicleDetails != null && customerCreatedUpdated != null)
                {
                    if (vehicleId == 0)
                    {
                        vehicleDetails.customerId = customerCreatedUpdated.customerId;
                        var vehicle = mapper.Map<VehicleDetails>(vehicleDetails);
                        var result = await vehicleDetailsRepo.addVehicle(vehicle);
                        vehicleId = result.vehicleId;
                    }
                }
                if (vehicleServiceDetail != null && customerCreatedUpdated != null)
                {
                    if (vehicleServiceDetail.VehicleServiceRecieveDelivery != null)
                    {
                        vehicleServiceDetail.VehicleServiceRecieveDelivery.vehicleReceiveDate = DateTime.UtcNow;
                        DateTime dateTime = new DateTime(1970, 1, 1, 5, 30, 0);
                        DateTime utcDateTime = dateTime.ToUniversalTime();
                        vehicleServiceDetail.VehicleServiceRecieveDelivery.vehicleDeliveryDate = utcDateTime;
                    }
                    //var json = JsonSerializer.Serialize(vehicleServiceDetail);
                    //Console.WriteLine(json);
                    var service = mapper.Map<VehicleServiceDetail>(vehicleServiceDetail);

                    service.vehicleId = vehicleId;
                    service.customerId = customerProfile.customerId;

                    await serviceDetailRepo.addServiceData(service);
                }
                resObj.action = "success";
                resObj.message = "Customer data & service data created successfully.";
                return resObj;
            } catch (Exception ex)
            {
                resObj.action = "error";
                resObj.message = "System Exception: " + ex.Message;
                return resObj;
            }
            
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
                //var taskList = await taskRepo.vehicleServiceTaskCompletedListsByCustId(result.CustomerProfile.customerId);
                //result.vehicleServiceDetails.ForEach(async service =>
                //{
                //    var taskListForService = taskList.Where(x => x.vehicleServiceDetailId == service.vehicleServiceDetailId).ToList();
                //    service.VehicleServiceTaskCompletedLists = mapper.Map<List<VehicleServiceTaskCompletedListDTO>>(taskListForService);
                //});
                var vehList = await vehicleDetailsRepo.getVehiclesByCustomerId(result.CustomerProfile.customerId);
                result.vehicleDetails = mapper.Map<List<VehicleDetailsDTO>>(vehList);
            }
            
            return result;
        }

        public async Task<ServiceDTOwithPagination> getAllCustomers(int pageNo, int pageSize)
        {
            var customers = await customerRepo.getAllCustomers(pageNo, pageSize);
            var customerListDto = new ServiceDTOwithPagination();
            var serviceDTO = new List<ServiceDTO>();
            foreach (var customer in customers)
            {
                ServiceDTO dto = new ServiceDTO();
                dto.CustomerProfile = customer;
                if (dto.CustomerProfile != null)
                {
                    long customerId = dto.CustomerProfile.customerId;
                    var serviceDetails = await serviceDetailRepo.getVehicleServiceByCustomerId(customerId);
                    dto.vehicleServiceDetails = mapper.Map<List<VehicleServiceDetailDTO>>(serviceDetails);
                }

                //if (dto.CustomerProfile != null && dto.vehicleServiceDetails != null)
                //{
                //    var taskList = await taskRepo.vehicleServiceTaskCompletedListsByCustId(dto.CustomerProfile.customerId);
                //    dto.vehicleServiceDetails.ForEach(async service =>
                //    {
                //        var taskListForService = taskList.Where(x => x.vehicleServiceDetailId == service.vehicleServiceDetailId).ToList();
                //        service.VehicleServiceTaskCompletedLists = mapper.Map<List<VehicleServiceTaskCompletedListDTO>>(taskListForService);
                //    });
                //}
                serviceDTO.Add(dto);
            }
            customerListDto.customersList = serviceDTO;
            customerListDto.totalCount = customerRepo.getAllCustomersCount();
            customerListDto.totalPages = (int)Math.Ceiling((double)customerListDto.totalCount / pageSize);
            customerListDto.currentPage = pageNo;
            return customerListDto;
        }

        //public async Task<bool> addCompletedTasks(List<ServiceCompletedTask> tasks)
        //{
        //    var result = await customerRepo.addCompletedTasks(tasks);
        //    return result;
        //}

        public async Task<List<ServiceTaskMaster>> getAllTaskMaster()
        {
            return await customerRepo.getAllTaskMaster();
        }
    }
}
