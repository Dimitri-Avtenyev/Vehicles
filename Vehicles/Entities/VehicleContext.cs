using System;
using Microsoft.EntityFrameworkCore;
using Vehicles.Models;

namespace Vehicles.Entities
{
	public class VehicleContext : DbContext
	{
		public DbSet<Vehicle> Vehicles { get; set; }
		public VehicleContext(DbContextOptions options):base(options)
		{

		}
	}
}

