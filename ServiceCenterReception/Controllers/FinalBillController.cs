using Microsoft.AspNetCore.Mvc;
using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Service;

namespace ServiceCenterReception.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinalBillController : Controller
    {
        private readonly IFinalBillSvc billSvc;

        public FinalBillController(IFinalBillSvc billSvc)
        {
            this.billSvc = billSvc;
        }

        [HttpPost]
        public async Task<generalResponseDTO> generateFinalBill(FinalServiceBill bill)
        {
            return await billSvc.generateFinalBill(bill);
        }
    }
}
