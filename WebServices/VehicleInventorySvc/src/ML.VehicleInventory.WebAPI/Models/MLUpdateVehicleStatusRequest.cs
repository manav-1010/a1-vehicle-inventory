using System.ComponentModel.DataAnnotations;
using VehicleInventory.Domain.Enums;

namespace ML.VehicleInventory.WebAPI.Models
{
    public class MLUpdateVehicleStatusRequest
    {
        [Required]
        public VehicleStatus Status { get; set; }
    }
}
