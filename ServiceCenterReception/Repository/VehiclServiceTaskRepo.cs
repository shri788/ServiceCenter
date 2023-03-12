using ServiceCenterReception.Data;
using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public class VehiclServiceTaskRepo: IVehicleServiceTaskRepo
    {
        private readonly serviceCenterDbContext context;

        public VehiclServiceTaskRepo(serviceCenterDbContext context)
        {
            this.context = context;
        }

        public async Task<generalResponseDTO> addTasks(VehicleServiceTaskCompletedList list)
        {
            try
            {
                await context.vehicleServiceTaskCompletedLists.AddRangeAsync(list);
                await context.SaveChangesAsync();
                generalResponseDTO resObj = new generalResponseDTO();
                resObj.action = "success";
                resObj.message = "All vehicle service related tasks added successfully";
                return resObj;
            } catch(Exception ex)
            {
                return null;
            }
        }
    }
}
