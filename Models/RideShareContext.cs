using Microsoft.EntityFrameworkCore;

namespace AdessoRideShare.Models
{
    public class RideShareContext : DbContext
    {
        public RideShareContext(DbContextOptions<RideShareContext> options)
           : base(options)
        {
        }

        public DbSet<RidePlan> RidePlans { get; set; }
        public DbSet<SharedRides> SharedRides { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<RidePossibleRoutes> RidePossibleRoutes { get; set; }

    }
}
