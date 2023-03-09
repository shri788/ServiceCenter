using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Service
{
    public interface ICustomerProfileSvc
    {
        Task<CustomerProfile> addCustomer(CustomerProfile customer);
    }
}
