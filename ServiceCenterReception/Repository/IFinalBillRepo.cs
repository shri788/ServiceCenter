using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public interface IFinalBillRepo
    {
        Task<generalResponseDTO> generateFinalBill(FinalServiceBill bill);
    }
}
