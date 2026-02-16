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
    }
}
