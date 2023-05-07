using System;
using Vehicles.Models;

namespace Vehicles.Services
{
	public interface IVehicleRepository
	{
		IEnumerable<Vehicle> GetAll();
		Vehicle Get(int id);
		void Add(Vehicle vehicle);
		void Delete(Vehicle vehicle);
		void Update(Vehicle vehicle);
	}
}

