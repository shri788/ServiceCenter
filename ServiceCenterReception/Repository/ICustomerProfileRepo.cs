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

        //Task<bool> addCompletedTasks(List<ServiceCompletedTask> tasks);

        Task<CustomerProfile> getCustomerByCustomerId(long customerId);

        long getAllCustomersCount();

        Task<List<ServiceTaskMaster>> getAllTaskMaster();
    }
}
