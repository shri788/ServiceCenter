using ServiceCenterReception.Entity;
using ServiceCenterReception.Repository;

namespace ServiceCenterReception.Service
{
    public class CustomerProfileSvc: ICustomerProfileSvc
    {
        private readonly ICustomerProfileRepo customerRepo;

        public CustomerProfileSvc(ICustomerProfileRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public Task<CustomerProfile> addCustomer(CustomerProfile customer)
        {
            return customerRepo.addCustomer(customer);
        }
    }
}
