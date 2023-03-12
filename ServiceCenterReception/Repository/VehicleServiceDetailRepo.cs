using ServiceCenterReception.Data;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public class VehicleServiceDetailRepo: IVehicleServiceDetailRepo
    {
        private readonly serviceCenterDbContext context;

        public VehicleServiceDetailRepo(serviceCenterDbContext context)
        {
            this.context = context;
        }

        public async Task<VehicleServiceDetail> addServiceData(VehicleServiceDetail service)
        {
            context.vehicleServiceDetails.Add(service);
            await context.SaveChangesAsync();
            return service;
        }
    }
}
