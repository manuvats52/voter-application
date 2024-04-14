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
        public DbSet<users> Users { get; set; } // DbSet for the users model
        public DbSet<State> States { get; set; } // DbSet for the State model
        public DbSet<City> Cities { get; set; } // DbSet for the City model
        public DbSet<Constituency> Constituencies { get; set; } // DbSet for the Constituency model
    }
}