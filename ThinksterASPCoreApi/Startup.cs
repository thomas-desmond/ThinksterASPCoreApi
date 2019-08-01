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
            var dbContext = serviceProvider.GetService<SpaceDatabaseContext>();
            dbContext.Database.EnsureCreated();

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
        }

        private void AddTestData(SpaceDatabaseContext context)
        {
            var mercury = new Planet
            {
                Id = 1,
                Name = "Mercury",
                Mass = "3.285 × 10^23 kg",
                Moons = new List<Moon>()
            };

            var venus = new Planet
            {
                Id = 1,
                Name = "Venus",
                Mass = "4.867 × 10^24 kg",
                Moons = new List<Moon>()
            };

            var earth = new Planet
            {
                Id = 3,
                Name = "Earth",
                Mass = "5.972 × 10^24 kg",
                Moons = new List<Moon>
                {
                    new Moon
                    {
                        Id = 1,
                        Name = "Moon",
                    }
                }
            };

            context.Planets.Add(mercury);
            context.Planets.Add(venus);
            context.Planets.Add(earth);

            context.SaveChanges();
        }
    }
}
