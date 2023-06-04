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

        public async Task<CustomerProfile> updateCustomer(CustomerProfile customer)
        {
            try
            {
                context.customerProfiles.Update(customer);
                await context.SaveChangesAsync();
                return customer;
            } catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CustomerProfile> getCustomerByMobileNo(long mobileNo)
        {
            try
            {
                var result = await context.customerProfiles.Where(x =>
                    x.mobileNumber == mobileNo)
                    .FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CustomerProfile> getCustomerByCustomerId(long customerId)
        {
            try
            {
                var result = await context.customerProfiles.Where(x =>
                    x.customerId == customerId)
                    .FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<CustomerProfile>> getAllCustomers(int pageNo, int pageSize)
        {
            try
            {
                var skip = (pageNo - 1) * pageSize;
                var customers = await context.customerProfiles
                                   .OrderBy(x => x.customerId)
                                   .Skip(skip).Take(pageSize)
                                   .ToListAsync();
                return customers;
            } catch (Exception ex)
            {
                return null;
            }
        }

        public long getAllCustomersCount()
        {
            try
            {
                var customersCount = context.customerProfiles.Count();
                return customersCount;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        //public async Task<bool> addCompletedTasks(List<ServiceCompletedTask> tasks)
        //{
        //    try
        //    {
        //        context.serviceCompletedTasks.AddRange(tasks);
        //        return true;
        //    } catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public async Task<List<ServiceTaskMaster>> getAllTaskMaster()
        {
            try
            {
                var result = await context.serviceTaskMasters.ToListAsync();
                return result;
            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}
