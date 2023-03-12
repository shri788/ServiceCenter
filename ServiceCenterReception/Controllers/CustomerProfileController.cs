using Microsoft.AspNetCore.Mvc;
using ServiceCenterReception.DTO;
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
        public async Task<generalResponseDTO> addCustomer(CustomerVehicleServiceDTO customer)
        {
            return await customerSvc.addCustomer(customer);
        }

        [HttpGet]
        [Route("getByMobileNo/{mobileNo}")]
        public async Task<ServiceDTO> getCustomerByMobileNo(long mobileNo)
        {
            return await customerSvc.getCustomerByMobilrNo(mobileNo);
        }
    }
}
