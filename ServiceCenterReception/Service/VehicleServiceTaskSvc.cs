using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Repository;

namespace ServiceCenterReception.Service
{
    public class VehicleServiceTaskSvc: IVehicleServiceTaskSvc
    {
        private readonly IVehicleServiceTaskRepo taskRepo;

        private readonly IVehicleServiceDetailRepo detailRepo;

        public VehicleServiceTaskSvc(IVehicleServiceTaskRepo taskRepo, IVehicleServiceDetailRepo detailRepo)
        {
            this.taskRepo = taskRepo;
            this.detailRepo = detailRepo;
        }

        //public async Task<generalResponseDTO> addTasks(List<VehicleServiceTaskCompletedList> list)
        //{
        //    var serviceDetails = await detailRepo.getVehicleServiceByServiceId(list[0].vehicleServiceDetailId);
        //    list.ForEach(service =>
        //    {
        //        service.customerId = serviceDetails.customerId;
        //    });
        //    return await taskRepo.addTasks(list);
        //}
    }
}
