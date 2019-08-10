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

            var moon = new Moon
            {
                Id = 1,
                PlanetId = 3,
                Name = "Moon"
            };
            modelBuilder.Entity<Moon>().HasData(moon);

            modelBuilder.Entity<Planet>().HasData(mercury);
            modelBuilder.Entity<Planet>().HasData(venus);
            modelBuilder.Entity<Planet>().HasData(earth);

            var sun = new Star
            {
                Id = 1,
                Name = "Sun",
                AgeInMillions = 4603,
            };

            var sirius = new Star
            {
                Id = 2,
                Name = "Sirius",
                AgeInMillions = 300,
            };

            var betelgeuse = new Star
            {
                Id = 3,
                Name = "Betelgeuse",
                AgeInMillions = 10.01,
            };

            var rigel = new Star
            {
                Id = 4,
                Name = "Rigel",
                AgeInMillions = 8.005,
            };

            var pollux = new Star
            {
                Id = 5,
                Name = "Pollux",
                AgeInMillions = 724.5,
            };

            modelBuilder.Entity<Star>().HasData(sun);
            modelBuilder.Entity<Star>().HasData(sirius);
            modelBuilder.Entity<Star>().HasData(betelgeuse);
            modelBuilder.Entity<Star>().HasData(rigel);
            modelBuilder.Entity<Star>().HasData(pollux);
        }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Moon> Moons { get; set; }

        public DbSet<Star> Stars { get; set; }
    }
}
