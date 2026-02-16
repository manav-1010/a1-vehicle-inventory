using VehicleInventory.Domain.Enums;
using VehicleInventory.Domain.Exceptions;

namespace VehicleInventory.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; private set; }
        public string VehicleCode { get; private set; } = string.Empty;
        public int LocationId { get; private set; }
        public string VehicleType { get; private set; } = string.Empty;
        public VehicleStatus Status { get; private set; } = VehicleStatus.Available;

        // for EF Core
        private Vehicle() { }

        public Vehicle(string vehicleCode, int locationId, string vehicleType)
        {
            if (string.IsNullOrWhiteSpace(vehicleCode))
                throw new DomainException("VehicleCode is required.");

            if (locationId <= 0)
                throw new DomainException("LocationId must be a positive number.");

            if (string.IsNullOrWhiteSpace(vehicleType))
                throw new DomainException("VehicleType is required.");

            VehicleCode = vehicleCode.Trim();
            LocationId = locationId;
            VehicleType = vehicleType.Trim();
            Status = VehicleStatus.Available;
        }

        // Will add rules later
        public void MarkAvailable()
        {
            Status = VehicleStatus.Available;
        }

        public void MarkRented()
        {
            Status = VehicleStatus.Rented;
        }

        public void MarkReserved()
        {
            Status = VehicleStatus.Reserved;
        }

        public void MarkServiced()
        {
            Status = VehicleStatus.Serviced;
        }
    }
}
