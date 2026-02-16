using Microsoft.AspNetCore.Mvc;
using ML.VehicleInventory.Application.Services;

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

        // GET: /api/vehicles/
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);

            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }


    }
}
