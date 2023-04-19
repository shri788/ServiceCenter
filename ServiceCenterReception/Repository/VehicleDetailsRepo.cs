using Microsoft.EntityFrameworkCore;
using ServiceCenterReception.Data;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public class VehicleDetailsRepo: IVehicleDetailsRepo
    {
        private readonly serviceCenterDbContext context;

        public VehicleDetailsRepo(serviceCenterDbContext context)
        {
            this.context = context;
        }

        public async Task<VehicleDetails> addVehicle(VehicleDetails vehicle)
        {
            try
            {
                context.vehicleDetails.Add(vehicle);
                await context.SaveChangesAsync();
                return vehicle;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<VehicleDetails> getVehicle(long vehicleId)
        {
            try
            {
                var result = await context.vehicleDetails.Where(x =>
                x.vehicleId == vehicleId).FirstOrDefaultAsync();
                return result;
            } catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<List<VehicleDetails>> getVehiclesByCustomerId(long customerId)
        {
            try
            {
                return await context.vehicleDetails.Where(x => 
                    x.customerId == customerId).ToListAsync();
            } catch (Exception ex)
            {
                return null;
            }
        }
    }
}
