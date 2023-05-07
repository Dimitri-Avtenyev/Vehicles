using System;
namespace Vehicles.Models
{
	public class Vehicle
	{
		public int Id { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public string VIN { get; set; }
		public VehicleTypeEnum Type { get; set; }
		public ColorEnum Color { get; set; }
	}
}

