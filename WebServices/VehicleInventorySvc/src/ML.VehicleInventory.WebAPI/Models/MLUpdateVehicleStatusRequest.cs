using VehicleInventory.Domain.Enums;

namespace ML.VehicleInventory.WebAPI.Models
{
    public class MLUpdateVehicleStatusRequest
    {
        public VehicleStatus Status { get; set; }
    }
}
