using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceCenterReception.Data;
using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public class VehicleServiceDeliveryRepo: IVehicleServiceDeliveryRepo
    {
        private readonly serviceCenterDbContext context;

        private readonly IMapper mapper;

        public VehicleServiceDeliveryRepo(serviceCenterDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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

        public async Task<List<VehicleServiceDTO>> getInProcessServices()
        {
            try
            {
                var result = await context.vehicleServiceDetails
                        .Include(x => x.VehicleServiceRecieveDelivery)
                        .Where(x => 
                        x.VehicleServiceRecieveDelivery.vehicleDeliveryDate == new DateTime(1970, 1, 1, 5, 30, 0))
                        .Include(a => a.CustomerProfile)
                        //.Include(a => a.VehicleDetails)
                        .ToListAsync();
                var resDto = mapper.Map<List<VehicleServiceDTO>>(result);

                return resDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<VehicleServiceDTO>> getCompletedServicesBetweenDates(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var result = await context.vehicleServiceDetails
                         .Include(x => x.VehicleServiceRecieveDelivery)
                         .Where(x =>
                         x.VehicleServiceRecieveDelivery.vehicleDeliveryDate >= startDate &&
                         x.VehicleServiceRecieveDelivery.vehicleDeliveryDate <= endDate)
                         .Include(a => a.CustomerProfile)
                         //.Include(a => a.VehicleDetails)
                         .ToListAsync();
                var resDto = mapper.Map<List<VehicleServiceDTO>>(result);
                return resDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
