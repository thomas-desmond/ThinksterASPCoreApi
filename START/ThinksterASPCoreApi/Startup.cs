using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThinksterASPCoreApi.DatabaseEntities;
using ThinksterASPCoreApi.Repository;

namespace ThinksterASPCoreApi
{
    public class Startup
    {
        SpaceDatabaseContext _dbContext;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SpaceDatabaseContext>(opt => opt.UseInMemoryDatabase("MyDatabase"));
            services.AddScoped<ISpaceRepository, SpaceRepository>();

            var serviceProvider = services.BuildServiceProvider();
            _dbContext = serviceProvider.GetService<SpaceDatabaseContext>();
            _dbContext.Database.EnsureCreated();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseMvc();
            AddTestData(app);
        }

        private async void AddTestData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<SpaceDatabaseContext>();
                if (context.Planets.Count() <= 0)
                {
                    BuildPlanetData(context);
                }
                if (context.Stars.Count() <= 0)
                {
                    BuildStarData(context);
                }

                await context.SaveChangesAsync();
            }


        }

        private void BuildStarData(SpaceDatabaseContext context)
        {

            var sunFact = new StarFact
            {
                Fact = "The Maunder Minimum was between 1645 and 1715 when the Sun went through a very inactive stage.",
                Source = "thesolarexplorer.net",
            };

            var sun = new Star
            {
                Name = "Sun",
                AgeInMillions = 4603,
                Fact = sunFact,
            };

            var siriusFact = new StarFact
            {
                Fact = "It had about five times the mass of the Sun.",
                Source = "easyscienceforkids.com",
            };

            var sirius = new Star
            {
                Name = "Sirius",
                AgeInMillions = 300,
                Fact = siriusFact,
            };

            var betelgeuseFact = new StarFact
            {
                Fact = "There has been great debate over which spelling of his name is correct.",
                Source = "stackexchange.com",
            };

            var betelgeuse = new Star
            {
                Name = "Betelgeuse",
                AgeInMillions = 10.01,
                Fact = betelgeuseFact,
            };

            var rigelFact = new StarFact
            {
                Fact = "Light from Rigel (left of center) is reflected of the ghostly Witch Head nebula.",
                Source = "solarsystemquick.com",
            };

            var rigel = new Star
            {
                Name = "Rigel",
                AgeInMillions = 8.005,
                Fact = rigelFact,
            };

            var polluxFact = new StarFact
            {
                Fact = "Pollux is a star that lies in the constellation Gemini.",
                Source = "space.com",
            };

            var pollux = new Star
            {
                Name = "Pollux",
                AgeInMillions = 724.5,
                Fact = polluxFact,
            };

            context.Stars.Add(sun);
            context.Stars.Add(sirius);
            context.Stars.Add(betelgeuse);
            context.Stars.Add(rigel);
            context.Stars.Add(pollux);
        }

        private static void BuildPlanetData(SpaceDatabaseContext context)
        {
            var mercury = new Planet
            {
                Name = "Mercury",
                Mass = "3.285 × 10^23 kg",
            };

            var venus = new Planet
            {
                Name = "Venus",
                Mass = "4.867 × 10^24 kg",
            };


            var moon = new Moon
            {
                Name = "Moon",
            };

            context.Moons.Add(moon);

            var earth = new Planet
            {
                Name = "Earth",
                Mass = "5.972 × 10^24 kg",
                Moons = new List<Moon> { moon }
            };

            context.Planets.Add(mercury);
            context.Planets.Add(venus);
            context.Planets.Add(earth);
        }
    }
}
