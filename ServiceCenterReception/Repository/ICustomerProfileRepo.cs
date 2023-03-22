using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public interface ICustomerProfileRepo
    {
        public Task<CustomerProfile> addCustomer(CustomerProfile customer);

        Task<CustomerProfile> updateCustomer(CustomerProfile customer);

        Task<CustomerProfile> getCustomerByMobileNo(long mobileNo);

        Task<List<CustomerProfile>> getAllCustomers(int pageNo, int pageSize);

        long getAllCustomersCount();
    }
}
