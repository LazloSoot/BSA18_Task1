using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Converters;
using ProjectStructure.Domain.Interfaces;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.Infrastructure.BL;
using ProjectStructure.Infrastructure.Data.Memory;
using ProjectStructure.Domain;

namespace ProjectStructure.WebApi
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
            services.AddMvc();


            services.AddSingleton(new AirportContext());
            // aircraft
            //  repos
            services.AddScoped(typeof(IRepository<Plane>), typeof(PlanesRepository));
            services.AddScoped(typeof(IRepository<PlaneType>), typeof(PlaneTypesRepository));
            services.AddScoped(typeof(IAircraftUnitOfWork), typeof(AircraftUnitOfWork));
            //  services
            services.AddScoped(typeof(IAircraftService), typeof(AircraftService));

            // aircraft
            //  repos
            services.AddScoped(typeof(IRepository<Crew>), typeof(CrewsRepository));
            services.AddScoped(typeof(IRepository<Pilot>), typeof(PilotsRepository));
            services.AddScoped(typeof(IRepository<Stewardess>), typeof(StewardessesRepository));
            services.AddScoped(typeof(ICrewingUnitOfWork), typeof(CrewingUnitOfWork));
            //  services
            services.AddScoped(typeof(ICrewingService), typeof(CrewingService));

            // aircraft
            //  repos
            services.AddScoped(typeof(IRepository<Flight>), typeof(FlightsRepository));
            services.AddScoped(typeof(IRepository<Departure>), typeof(DeparturesRepository));
            services.AddScoped(typeof(IRepository<Ticket>), typeof(TicketsRepository));
            services.AddScoped(typeof(IFlightOperationsUnitOfWork), typeof(FlightOperationsUnitOfWork));
            //  services
            services.AddScoped(typeof(IFlightOperationsService), typeof(FlightOperationsService));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
