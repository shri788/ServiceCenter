using Microsoft.EntityFrameworkCore;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Data
{
    public class serviceCenterDbContext : DbContext
    {
        public serviceCenterDbContext(DbContextOptions<serviceCenterDbContext> options)
            : base(options) {
                    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                }

            public DbSet<CustomerProfile> customerProfiles { get; set; } = null!;

            public DbSet<VehicleDetails> vehicleDetails { get; set; } = null!;

            public DbSet<VehicleServiceRecieveDelivery> vehicleServiceRecieveDeliveries { get; set; } = null!;

            public DbSet<VehicleServiceDetail> vehicleServiceDetails { get; set; } = null!;

            public DbSet<VehicleServiceTaskCompletedList> vehicleServiceTaskCompletedLists { get; set; } = null!;
            
            public DbSet<ServiceTasksMaster> serviceTasksMasters { get; set; } = null!;

            public DbSet<FinalServiceBill> finalServiceBills { get; set; } = null!;

    }
} 
