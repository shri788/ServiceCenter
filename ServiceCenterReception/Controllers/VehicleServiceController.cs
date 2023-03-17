using Microsoft.AspNetCore.Mvc;
using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Service;

namespace ServiceCenterReception.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleServiceController : Controller
    {
        private readonly IVehicleServiceDeliverySvc deliverySvc;

        public VehicleServiceController(IVehicleServiceDeliverySvc deliverySvc)
        {
            this.deliverySvc = deliverySvc;
        }

        [HttpGet]
        [Route("getInProcessServices")]
        public async Task<List<VehicleServiceDTO>> getInProcessServices()
        {
            return await deliverySvc.getInProcessServices();
        }

        [HttpGet]
        [Route("getCompletedServicesBetweenDate/{startDate}/{endDate}")]
        public async Task<List<VehicleServiceDTO>> getCompletedServicesBetweenDates(DateTime? startDate, DateTime? endDate)
        {
            return await deliverySvc.getCompletedServicesBetweenDates(startDate, endDate);
        }
    }
}
