using VehicleInventory.Domain.Enums;

namespace ML.VehicleInventory.Application.DTOs
{
    public class MLVehicleDto
    {
        public int Id { get; set; }
        public string VehicleCode { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public string VehicleType { get; set; } = string.Empty;
        public VehicleStatus Status { get; set; }
    }
}
