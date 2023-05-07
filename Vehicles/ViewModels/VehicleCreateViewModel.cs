using System;
using System.ComponentModel.DataAnnotations;
using Vehicles.Models;

namespace Vehicles.ViewModels
{
	public class VehicleCreateViewModel
	{
		[Required]
		public string Make { get; set; }

		[Required]
		public string Model { get; set; }

		[Required]
		public string VIN { get; set; }

		public VehicleTypeEnum Type { get; set; }
		public ColorEnum Color { get; set; }
	}
}

