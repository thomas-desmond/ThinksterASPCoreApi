using Microsoft.EntityFrameworkCore;
using ThinksterASPCoreApi.DatabaseEntities;

namespace ThinksterASPCoreApi
{
    public class SpaceDatabaseContext : DbContext
    {
        public SpaceDatabaseContext(DbContextOptions<SpaceDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>().HasData(new Planet
            {
                Id = "1",
                Name = "Earth"
            });

            modelBuilder.Entity<Star>().HasData(new Star
            {
                Id = "1",
                Name = "Sun",
            });
        }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Moon> Moons { get; set; }

        public DbSet<Star> Stars { get; set; }
    }
}
