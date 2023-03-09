using Microsoft.EntityFrameworkCore;
using ServiceCenterReception.Entity;

namespace ServiceCenterReception.Data
{
    public class serviceCenterDbContext : DbContext
    {
        public serviceCenterDbContext(DbContextOptions<serviceCenterDbContext> options)
            : base(options) { }

            public DbSet<CustomerProfile> customerProfiles { get; set; } = null!;
    }
}
