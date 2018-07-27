using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectStructure.Domain.Interfaces;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.Infrastructure.BL;
using ProjectStructure.Databases.MSSQL;
using ProjectStructure.Domain;
using ProjectStructure.Infrastructure.Data.Aircraft;
using ProjectStructure.Infrastructure.Data.Crewing;
using ProjectStructure.Infrastructure.Data.FlightOperations;
using ProjectStructure.Infrastructure.Data;
using mapper = ProjectStructure.Infrastructure.Shared.Mappings.AutoMapper;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared.Helpers;

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
			services.AddCors();

            // context
            services.AddScoped(typeof(AirportContext), typeof(MSSQLContext));

            // automapper
            services.AddScoped<IMapper>(sp => mapper.GetDefaultMapper());
            // aircraft
            //  repos
            services.AddScoped(typeof(EFRepository<Plane>), typeof(PlanesRepository));
            services.AddScoped(typeof(EFRepository<PlaneType>), typeof(PlaneTypesRepository));
            services.AddScoped(typeof(IDbAircraftUnitOfWork), typeof(AircraftUnitOfWork));

            services.AddScoped(typeof(EFRepository<Plane>), typeof(PlanesRepository));
            services.AddScoped(typeof(EFRepository<PlaneType>), typeof(PlaneTypesRepository));
            services.AddScoped(typeof(IDbAircraftUnitOfWork), typeof(AircraftUnitOfWork));
            //  services
            services.AddScoped(typeof(IAircraftService), typeof(AircraftService));

            // aircraft
            //  repos
            services.AddScoped(typeof(EFRepository<Crew>), typeof(CrewsRepository));
            services.AddScoped(typeof(EFRepository<Pilot>), typeof(PilotsRepository));
            services.AddScoped(typeof(EFRepository<Stewardess>), typeof(StewardessesRepository));
            services.AddScoped(typeof(IDbCrewingUnitOfWork), typeof(CrewingUnitOfWork));
            //  services
            services.AddScoped(typeof(ICrewingService), typeof(CrewingService));
				
            // aircraft
            //  repos
            services.AddScoped(typeof(EFRepository<Flight>), typeof(FlightsRepository));
            services.AddScoped(typeof(EFRepository<Departure>), typeof(DeparturesRepository));
            services.AddScoped(typeof(EFRepository<Ticket>), typeof(TicketsRepository));
            services.AddScoped(typeof(IDbFlightOperationsUnitOfWork), typeof(FlightOperationsUnitOfWork));
            //  services
            services.AddScoped(typeof(IFlightOperationsService), typeof(FlightOperationsService));

			services.AddCors(options => {
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials());
			});

		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			
			app.UseCorsMiddleware();
			app.UseMvc();
			app.UseCors("CorsPolicy");
			app.UseDefaultFiles();
			app.UseStaticFiles();
		}
    }
}
