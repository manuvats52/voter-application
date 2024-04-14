using Microsoft.EntityFrameworkCore;
using voter_application.Models;

namespace voter_application.Data
{
    public class VoterDbContext : DbContext
    {
        public VoterDbContext(DbContextOptions<VoterDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for your model classes
        public DbSet<users> Users { get; set; }
        // Add DbSet properties for other model classes if needed
    }
}
