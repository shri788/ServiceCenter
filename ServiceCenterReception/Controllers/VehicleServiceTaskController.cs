using Microsoft.AspNetCore.Mvc;
using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Service;

namespace ServiceCenterReception.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleServiceTaskController : Controller
    {
        private readonly IVehicleServiceTaskSvc taskSvc;

        public VehicleServiceTaskController(IVehicleServiceTaskSvc taskSvc)
        {
            this.taskSvc = taskSvc;
        }

        [HttpPost]
        public async Task<generalResponseDTO> addTasks(List<VehicleServiceTaskCompletedList> list)
        {
            return await taskSvc.addTasks(list);
        }
    }
}
