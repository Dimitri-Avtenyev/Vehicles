using System;
using System.ComponentModel.DataAnnotations;
using Vehicles.Models;

namespace Vehicles.ViewModels
{
	public class VehicleUpdateViewModel
	{
		[Required]
		public string VIN { get; set; }

		public ColorEnum Color { get; set; }
	}
}

