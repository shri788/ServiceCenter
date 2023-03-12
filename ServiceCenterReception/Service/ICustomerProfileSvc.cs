using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Service
{
    public interface ICustomerProfileSvc
    {
        Task<generalResponseDTO> addCustomer(CustomerVehicleServiceDTO customer);

        Task<CustomerVehicleServiceDTO> getCustomerByMobilrNo(long mobileNo);
    }
}
