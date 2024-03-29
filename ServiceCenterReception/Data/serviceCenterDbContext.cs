﻿using Microsoft.EntityFrameworkCore;
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

            //public DbSet<ServiceCompletedTask> serviceCompletedTasks { get; set; } = null!;
            
            public DbSet<ServiceTaskMaster> serviceTaskMasters { get; set; } = null!;

            public DbSet<FinalServiceBill> finalServiceBills { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerProfile>()
                .HasIndex(c => c.mobileNumber)
                .IsUnique();
        }
    }
} 
