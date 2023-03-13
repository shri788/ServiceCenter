using Microsoft.EntityFrameworkCore;
using ServiceCenterReception.Data;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public class VehicleServiceDetailRepo: IVehicleServiceDetailRepo
    {
        private readonly serviceCenterDbContext _context;

        public VehicleServiceDetailRepo(serviceCenterDbContext context)
        {
            _context = context;
        }

        public async Task<VehicleServiceDetail> addServiceData(VehicleServiceDetail service)
        {
            _context.vehicleServiceDetails.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<List<VehicleServiceDetail>> getVehicleServiceByCustomerId(long customerId)
        {
            try
            {
                var result = await _context.vehicleServiceDetails.Where(
                            x => x.customerId == customerId)
                            .Include(x => x.VehicleServiceRecieveDelivery)
                            .Include(x => x.VehicleDetails)
                            .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<VehicleServiceDetail> getVehicleServiceByServiceId(long serviceId)
        {
            try
            {
                var result = await _context.vehicleServiceDetails.Where(
                            x => x.vehicleServiceDetailId == serviceId)
                            .Include(x => x.VehicleServiceRecieveDelivery)
                            .FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<VehicleServiceDetail> updateServiceData(VehicleServiceDetail service)
        {
            try
            {
                _context.vehicleServiceDetails.Update(service);
                await _context.SaveChangesAsync();
                return service;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
