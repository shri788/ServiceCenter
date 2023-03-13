using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Service
{
    public interface IFinalBillSvc
    {
        Task<generalResponseDTO> generateFinalBill(FinalServiceBill bill);
    }
}
