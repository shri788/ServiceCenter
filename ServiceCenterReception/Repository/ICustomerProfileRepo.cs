using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public interface ICustomerProfileRepo
    {
        public Task<CustomerProfile> addCustomer(CustomerProfile customer);
    }
}
