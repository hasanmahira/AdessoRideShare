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
    }
}
