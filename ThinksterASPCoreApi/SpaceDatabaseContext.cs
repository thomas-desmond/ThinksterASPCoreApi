using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ThinksterASPCoreApi.DatabaseEntities;

namespace ThinksterASPCoreApi
{
    public class SpaceDatabaseContext : DbContext
    {
        public SpaceDatabaseContext(DbContextOptions<SpaceDatabaseContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    return;
        //    var mercury = new Planet
        //    {
        //        Id = 1,
        //        Name = "Mercury",
        //        Mass = "3.285 × 10^23 kg",
        //    };

        //    var venus = new Planet
        //    {
        //        Id = 2,
        //        Name = "Venus",
        //        Mass = "4.867 × 10^24 kg",
        //    };

  
        //    var earth = new Planet
        //    {
        //        Id = 3,
        //        Name = "Earth",
        //        Mass = "5.972 × 10^24 kg",
        //    };
        //    var moon = new Moon
        //    {
        //        Id = 1,
        //        PlanetId = earth.Id,
        //        Name = "Moon"
        //    };

        //    //modelBuilder.Entity<Moon>().HasData(moon);
            
        //    modelBuilder.Entity<Planet>().HasData(mercury);
        //    modelBuilder.Entity<Planet>().HasData(venus);
        //    modelBuilder.Entity<Planet>().HasData(earth);

        //    var sun = new Star
        //    {
        //        Id = 1,
        //        Name = "Sun",
        //        AgeInMillions = 4603,
        //    };

        //    var sunFact = new StarFact
        //    {
        //        Id = 1,
        //        StarId = 1,
        //        Fact = "The Maunder Minimum was between 1645 and 1715 when the Sun went through a very inactive stage.",
        //        Source = "thesolarexplorer.net",
        //    };

        //    var sirius = new Star
        //    {
        //        Id = 2,
        //        Name = "Sirius",
        //        AgeInMillions = 300,
        //    };

        //    var siriusFact = new StarFact
        //    {
        //        Id = 2,
        //        StarId = 2,
        //        Fact = "It had about five times the mass of the Sun.",
        //        Source = "easyscienceforkids.com",
        //    };

        //    var betelgeuse = new Star
        //    {
        //        Id = 3,
        //        Name = "Betelgeuse",
        //        AgeInMillions = 10.01,
        //    };

        //    var betelgeuseFact = new StarFact
        //    {
        //        Id = 3,
        //        StarId = 3,
        //        Fact = "There has been great debate over which spelling of his name is correct.",
        //        Source = "stackexchange.com",
        //    };

        //    var rigel = new Star
        //    {
        //        Id = 4,
        //        Name = "Rigel",
        //        AgeInMillions = 8.005,
        //    };

        //    var rigelFact = new StarFact
        //    {
        //        Id = 4,
        //        StarId = 4,
        //        Fact = "Light from Rigel (left of center) is reflected of the ghostly Witch Head nebula.",
        //        Source = "solarsystemquick.com",
        //    };

        //    var pollux = new Star
        //    {
        //        Id = 5,
        //        Name = "Pollux",
        //        AgeInMillions = 724.5,
        //    };

        //    var polluxFact = new StarFact
        //    {
        //        Id = 5,
        //        StarId = 5,
        //        Fact = "Pollux is a star that lies in the constellation Gemini.",
        //        Source = "space.com",
        //    };


        //    modelBuilder.Entity<StarFact>().HasData(sunFact);
        //    modelBuilder.Entity<StarFact>().HasData(siriusFact);
        //    modelBuilder.Entity<StarFact>().HasData(betelgeuseFact);
        //    modelBuilder.Entity<StarFact>().HasData(rigelFact);
        //    modelBuilder.Entity<StarFact>().HasData(polluxFact);


        //    modelBuilder.Entity<Star>().HasData(sun);
        //    modelBuilder.Entity<Star>().HasData(sirius);
        //    modelBuilder.Entity<Star>().HasData(betelgeuse);
        //    modelBuilder.Entity<Star>().HasData(rigel);
        //    modelBuilder.Entity<Star>().HasData(pollux);
        //}

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Moon> Moons { get; set; }

        public DbSet<Star> Stars { get; set; }
    }
}
