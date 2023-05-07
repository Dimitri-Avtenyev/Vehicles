using System;
using Microsoft.AspNetCore.Mvc;
using Vehicles.ViewModels;
using Vehicles.Services;
using Vehicles.Models;

namespace Vehicles.Controllers
{
	[Route("Home")]
	public class HomeController : Controller
	{
		private readonly IVehicleRepository _vehicleRepository;

		public HomeController(IVehicleRepository vehicleRepositoryInMemory)
		{
			_vehicleRepository = vehicleRepositoryInMemory;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_vehicleRepository.GetAll());
		}

		[HttpPut]
		public IActionResult Update(int id, [FromBody] VehicleUpdateViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var foundVehicle = _vehicleRepository.Get(id);
			if (foundVehicle is null)
			{
				return NotFound();
			}
			foundVehicle.VIN = model.VIN;
			foundVehicle.Color = model.Color;

			_vehicleRepository.Update(foundVehicle);
			return NoContent();
		}

		[HttpPost]
		public IActionResult Add([FromBody] VehicleCreateViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var newVehicle = new Vehicle()
			{
				Make = model.Make,
				Model = model.Model,
				VIN = model.VIN,
				Type = model.Type,
				Color = model.Color

			};
			_vehicleRepository.Add(newVehicle);
			//return CreatedAtAction(nameof(newVehicle), new { newVehicle.Id }, newVehicle);
			return Ok(newVehicle);
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var foundVehicle = _vehicleRepository.Get(id);
			if (foundVehicle is null)
			{
				return NotFound();
			}
			_vehicleRepository.Delete(foundVehicle);
			return NoContent();
		}

		[HttpGet("id")]
		public IActionResult Get(int id)
		{
			var vehicle = _vehicleRepository.Get(id);
			if(vehicle is null)
			{
				return NotFound();
			}
			return Ok(vehicle);
		}
	}
}

