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
            //AddTestData(dbContext);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
