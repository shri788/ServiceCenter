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
        [Route("profileWithService")]
        public async Task<generalResponseDTO> addCustomer(CustomerVehicleServiceDTO customer)
        {
            return await customerSvc.addCustomer(customer);
        }

        [HttpGet]
        [Route("getByMobileNo/{mobileNo}")]
        public async Task<ServiceDTO> getCustomerByMobileNo(long mobileNo)
        {
            return await customerSvc.getCustomerByMobileNo(mobileNo);
        }

        [HttpGet]
        [Route("getAllCustomers/{pageNo}/{pageSize}")]
        public async Task<ServiceDTOwithPagination> getAllCustomers(int pageNo, int pageSize)
        {
            return await customerSvc.getAllCustomers(pageNo, pageSize);
        }

        [HttpGet]
        [Route("getServiceTaskMaster")]
        public async Task<IActionResult> getAllTaskMaster()
        {
            var result = await customerSvc.getAllTaskMaster();
            return Ok(result);
        }
    }
}
