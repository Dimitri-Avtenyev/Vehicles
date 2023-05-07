using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Vehicles.Entities;
using Vehicles.Services;

namespace Vehicles
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen();
			services.AddScoped<IVehicleRepository,InMemoryVehicleRepository>();

			//-Voor EF demo -//
		   services.AddScoped<IVehicleRepository, EfVehicleRepository>();
			var connectionString = "server=localhost; port=3306; database=vehicles-db; user=root; password=Dimitri1290";
			services.AddDbContext<VehicleContext>(x =>
			{
				x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			});
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("./swagger/v1/swagger.json", "Vehicle API V1");
					c.RoutePrefix = string.Empty;
				});
			} else
			{
				app.UseExceptionHandler(new ExceptionHandlerOptions
				{
					ExceptionHandler = context => context.Response.WriteAsync("Something went wrong.")
				});
			}
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}
	}
}

