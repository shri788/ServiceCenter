using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Service
{
    public interface ICustomerProfileSvc
    {
        Task<generalResponseDTO> addCustomer(CustomerVehicleServiceDTO customer);

        Task<ServiceDTO> getCustomerByMobileNo(long mobileNo);

        Task<ServiceDTOwithPagination> getAllCustomers(int pageNo, int pageSize);
    }
}
