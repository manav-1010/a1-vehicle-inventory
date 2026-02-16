namespace ML.VehicleInventory.Application.DTOs
{
    public class MLCreateVehicleDto
    {
        public string VehicleCode { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public string VehicleType { get; set; } = string.Empty;
    }
}
