using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Repository;

namespace ServiceCenterReception.Service
{
    public class VehicleServiceTaskSvc: IVehicleServiceTaskSvc
    {
        private readonly IVehicleServiceTaskRepo taskRepo;

        public VehicleServiceTaskSvc(IVehicleServiceTaskRepo taskRepo)
        {
            this.taskRepo = taskRepo;
        }

        public async Task<generalResponseDTO> addTasks(VehicleServiceTaskCompletedList list)
        {
            return await taskRepo.addTasks(list);
        }
    }
}
