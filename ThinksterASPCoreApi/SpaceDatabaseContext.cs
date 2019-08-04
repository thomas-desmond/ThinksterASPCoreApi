using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            var mercury = new Planet
            {
                Id = 1,
                Name = "Mercury",
                Mass = "3.285 × 10^23 kg",
            };

            var venus = new Planet
            {
                Id = 2,
                Name = "Venus",
                Mass = "4.867 × 10^24 kg",
            };

            var earth = new Planet
            {
                Id = 3,
                Name = "Earth",
                Mass = "5.972 × 10^24 kg",
            };

            modelBuilder.Entity<Planet>().HasData(mercury);
            modelBuilder.Entity<Planet>().HasData(venus);
            modelBuilder.Entity<Planet>().HasData(earth);


            modelBuilder.Entity<Star>().HasData(new Star
            {
                Id = 1,
                Name = "Sun",
            });
        }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Moon> Moons { get; set; }

        public DbSet<Star> Stars { get; set; }
    }
}
