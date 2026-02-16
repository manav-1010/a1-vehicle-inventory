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

        public void MarkAvailable()
        {
            if (Status == VehicleStatus.Reserved)
                throw new DomainException("Reserved vehicle cannot be made available without releasing the reservation.");

            Status = VehicleStatus.Available;
        }

        public void MarkRented()
        {
            if (Status == VehicleStatus.Rented)
                throw new DomainException("Vehicle is already rented.");

            if (Status == VehicleStatus.Reserved)
                throw new DomainException("Vehicle cannot be rented while reserved.");

            if (Status == VehicleStatus.Serviced)
                throw new DomainException("Vehicle cannot be rented while under service.");

            Status = VehicleStatus.Rented;
        }

        public void MarkReserved()
        {
            if (Status != VehicleStatus.Available)
                throw new DomainException("Only available vehicles can be reserved.");

            Status = VehicleStatus.Reserved;
        }

        public void MarkServiced()
        {
            if (Status != VehicleStatus.Available)
                throw new DomainException("Only available vehicles can be marked as under service.");

            Status = VehicleStatus.Serviced;
        }

        public void ReleaseReservation()
        {
            if (Status != VehicleStatus.Reserved)
                throw new DomainException("Vehicle is not reserved.");

            Status = VehicleStatus.Available;
        }
    }
}
