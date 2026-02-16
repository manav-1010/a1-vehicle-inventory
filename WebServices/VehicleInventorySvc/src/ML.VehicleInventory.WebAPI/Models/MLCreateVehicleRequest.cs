using System.ComponentModel.DataAnnotations;

namespace ML.VehicleInventory.WebAPI.Models
{
    public class MLCreateVehicleRequest
    {
        [Required]
        [MaxLength(30)]
        public string VehicleCode { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int LocationId { get; set; }

        [Required]
        [MaxLength(50)]
        public string VehicleType { get; set; } = string.Empty;
    }
}
