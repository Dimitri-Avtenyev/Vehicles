using System;
using Vehicles.Models;
using Vehicles.Entities;

namespace Vehicles.Services
{
	public class EfVehicleRepository : IVehicleRepository
	{
		private readonly VehicleContext _context;

		public EfVehicleRepository(VehicleContext context) 
		{
			_context = context;
		}
		public IEnumerable<Vehicle> GetAll()
		{
			return _context.Vehicles;
		}
		public Vehicle Get(int id)
		{
			return _context.Vehicles.FirstOrDefault(x => x.Id == id);
		}
		public void Add(Vehicle vehicle)
		{
			_context.Vehicles.Add(vehicle);
			_context.SaveChanges();
		}
		public void Update(Vehicle vehicle)
		{
			var updatedVehicle = Get(vehicle.Id);
			updatedVehicle.VIN = vehicle.VIN;
			updatedVehicle.Color = vehicle.Color;
			_context.SaveChanges();
		}

		public void Delete(Vehicle vehicle)
		{
			_context.Vehicles.Remove(vehicle);
			_context.SaveChanges();
		}

	



		
	}
}

