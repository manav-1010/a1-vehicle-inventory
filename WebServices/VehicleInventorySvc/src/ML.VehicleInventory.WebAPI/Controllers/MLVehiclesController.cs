using Microsoft.AspNetCore.Mvc;
using ML.VehicleInventory.Application.DTOs;
using ML.VehicleInventory.Application.Services;
using ML.VehicleInventory.WebAPI.Models;

namespace ML.VehicleInventory.WebAPI.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class MLVehiclesController : ControllerBase
    {
        private readonly MLVehicleService _vehicleService;

        public MLVehiclesController(MLVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: /api/vehicles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            return Ok(vehicles);
        }

        // GET: /api/vehicles/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);

            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }

        // POST: /api/vehicles
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MLCreateVehicleRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var dto = new MLCreateVehicleDto
            {
                VehicleCode = request.VehicleCode,
                LocationId = request.LocationId,
                VehicleType = request.VehicleType
            };

            var created = await _vehicleService.CreateVehicleAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: /api/vehicles/{id}/status
        [HttpPut("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] MLUpdateVehicleStatusRequest request)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var dto = new MLUpdateVehicleStatusDto { Status = request.Status };

            var updated = await _vehicleService.UpdateVehicleStatusAsync(id, dto.Status);

            if (!updated)
                return NotFound();

            return NoContent();
        }


        // DELETE: /api/vehicles/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _vehicleService.DeleteVehicleAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
