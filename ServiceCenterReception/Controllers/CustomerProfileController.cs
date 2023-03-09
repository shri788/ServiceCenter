using Microsoft.AspNetCore.Mvc;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Service;

namespace ServiceCenterReception.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerProfileController : Controller
    {
        private readonly ICustomerProfileSvc customerSvc;

        public CustomerProfileController(ICustomerProfileSvc customerSvc)
        {
            this.customerSvc = customerSvc;
        }

        [HttpPost]
        public async Task<CustomerProfile> addCustomer(CustomerProfile customer)
        {
            return await customerSvc.addCustomer(customer);
        }
    }
}
