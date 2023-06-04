using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ServiceCenterReception.Data;
using ServiceCenterReception.DTO;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Repository
{
    public class VehiclServiceTaskRepo: IVehicleServiceTaskRepo
    {
        private readonly serviceCenterDbContext _context;

        public VehiclServiceTaskRepo(serviceCenterDbContext context)
        {
            _context = context;
        }

        //public async Task<generalResponseDTO> addTasks(List<VehicleServiceTaskCompletedList> list)
        //{
        //    try
        //    {
        //        list.ForEach(obj =>
        //        {
        //            _context.vehicleServiceTaskCompletedLists.Add(obj);
        //        });
        //        await _context.SaveChangesAsync();
        //        generalResponseDTO resObj = new generalResponseDTO();
        //        resObj.action = "success";
        //        resObj.message = "All vehicle service related tasks added successfully";
        //        return resObj;
        //    } catch(Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<List<VehicleServiceTaskCompletedList>> vehicleServiceTaskCompletedLists(long serviceId)
        //{
        //    try
        //    {
        //        var result = await _context.vehicleServiceTaskCompletedLists.Where(x =>
        //            x.vehicleServiceDetailId == serviceId)
        //            .ToListAsync();
        //        Console.WriteLine(result.Count());
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<List<VehicleServiceTaskCompletedList>> vehicleServiceTaskCompletedListsByCustId(long customerId)
        //{
        //    try
        //    {
        //        var result = await _context.vehicleServiceTaskCompletedLists.Where(x =>
        //            x.customerId == customerId)
        //            .ToListAsync();
        //        Console.WriteLine(result.Count());
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
