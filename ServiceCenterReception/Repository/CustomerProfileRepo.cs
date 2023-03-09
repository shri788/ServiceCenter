using ServiceCenterReception.Data;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public class CustomerProfileRepo: ICustomerProfileRepo
    {
        private readonly serviceCenterDbContext context;

        public CustomerProfileRepo(serviceCenterDbContext context)
        {
            this.context = context;
        }   

        public async Task<CustomerProfile> addCustomer(CustomerProfile customer)
        {
            context.customerProfiles.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }
    }
}
