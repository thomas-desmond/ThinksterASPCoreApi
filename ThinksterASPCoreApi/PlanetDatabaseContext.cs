using Microsoft.EntityFrameworkCore;
using ThinksterASPCoreApi.DatabaseModels;

namespace ThinksterASPCoreApi
{
    public class PlanetDatabaseContext : DbContext
    {
        public PlanetDatabaseContext(DbContextOptions<PlanetDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Moon> Moons { get; set; }
    }
}
