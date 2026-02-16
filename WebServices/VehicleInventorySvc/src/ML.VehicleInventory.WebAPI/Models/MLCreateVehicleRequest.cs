namespace ML.VehicleInventory.WebAPI.Models
{
    public class MLCreateVehicleRequest
    {
        public string VehicleCode { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public string VehicleType { get; set; } = string.Empty;
    }
}
