using Microsoft.EntityFrameworkCore;
using ServiceCenterReception.Data;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public class VehicleServiceDeliveryRepo: IVehicleServiceDeliveryRepo
    {
        private readonly serviceCenterDbContext context;

        public VehicleServiceDeliveryRepo(serviceCenterDbContext context)
        {
            this.context = context;
        }

        public async Task<VehicleServiceRecieveDelivery> getDeliveryById(long deliveryId)
        {
            try
            {
                var result = await context.vehicleServiceRecieveDeliveries.Where(x =>
                    x.VehicleServiceRecieveDeliveryId == deliveryId)
                    .FirstOrDefaultAsync();
                return result;
            } catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<VehicleServiceRecieveDelivery> updateDelivery(VehicleServiceRecieveDelivery delivery)
        {
            try
            {
                context.vehicleServiceRecieveDeliveries.Update(delivery);
                await context.SaveChangesAsync();
                return delivery;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
