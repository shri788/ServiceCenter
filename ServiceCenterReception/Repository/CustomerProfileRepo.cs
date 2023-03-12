using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceCenterReception.Data;
using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public class CustomerProfileRepo: ICustomerProfileRepo
    {
        private readonly serviceCenterDbContext context;

        private readonly IMapper mapper;

        public CustomerProfileRepo(serviceCenterDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }   

        public async Task<CustomerProfile> addCustomer(CustomerProfile customer)
        {
            try
            {
                context.customerProfiles.Add(customer);
                await context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CustomerVehicleServiceDTO> getCustomerByMobilrNo(long mobileNo)
        {
            try
            {
                var result = await context.customerProfiles.Where(x =>
                    x.mobileNumber == mobileNo)
                    .FirstOrDefaultAsync();
                var dto = mapper.Map<CustomerVehicleServiceDTO>(result);
                return dto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
