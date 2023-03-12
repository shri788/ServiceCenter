using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public interface IVehicleServiceDetailRepo
    {
        Task<VehicleServiceDetail> addServiceData(VehicleServiceDetail service);
    }
}
