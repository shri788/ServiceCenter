using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public interface IVehicleServiceDetailRepo
    {
        Task<VehicleServiceDetail> addServiceData(VehicleServiceDetail service);

        Task<List<VehicleServiceDetail>> getVehicleServiceByCustomerId(long customerId);

        Task<VehicleServiceDetail> getVehicleServiceByServiceId(long serviceId);
    }
}
