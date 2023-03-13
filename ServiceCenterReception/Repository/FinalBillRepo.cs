using ServiceCenterReception.Data;
using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public class FinalBillRepo: IFinalBillRepo
    {
        private readonly serviceCenterDbContext context;

        public FinalBillRepo(serviceCenterDbContext context)
        {
            this.context = context;
        }

        public async Task<generalResponseDTO> generateFinalBill(FinalServiceBill bill)
        {
            try
            {
                generalResponseDTO resObj = new generalResponseDTO();
                context.finalServiceBills.Add(bill);
                await context.SaveChangesAsync();
                resObj.action = "success";
                resObj.message = "Final Bill Generated Successfully.";
                return resObj;
            } catch(Exception ex)
            {
                return null;
            }
        }
    }
}
