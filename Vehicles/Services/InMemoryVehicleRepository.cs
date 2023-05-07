using System;
using Vehicles.Models;

namespace Vehicles.Services
{
	public class InMemoryVehicleRepository : IVehicleRepository
	{
		private static List<Vehicle> _vehicles;

		static InMemoryVehicleRepository()
		{
			_vehicles = new List<Vehicle>();
		}
		public IEnumerable<Vehicle> GetAll()
		{
			return _vehicles;
		}
		public Vehicle Get(int id)
		{
			return _vehicles.FirstOrDefault(x => x.Id == id);
		}
		public void Add(Vehicle vehicle)
		{
			if (_vehicles.Count > 0)
			{
				vehicle.Id = _vehicles.Max(x => x.Id) + 1;
			} else
			{
				vehicle.Id = 1;
			}
			
			_vehicles.Add(vehicle);
		}
		public void Update(Vehicle vehicle)
		{
			var updatedVehicle = Get(vehicle.Id);
			updatedVehicle.VIN = vehicle.VIN;
			updatedVehicle.Color = vehicle.Color;

		}
		public void Delete(Vehicle vehicle)
		{
			_vehicles.Remove(vehicle);
		}
	}
}

