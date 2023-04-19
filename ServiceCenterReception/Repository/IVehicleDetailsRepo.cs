using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public interface IVehicleDetailsRepo
    {
        Task<VehicleDetails> addVehicle(VehicleDetails vehicle);

        Task<VehicleDetails> getVehicle(long vehicleId);

        Task<List<VehicleDetails>> getVehiclesByCustomerId(long customerId);
    }
}
