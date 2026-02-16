using ML.VehicleInventory.Application.DTOs;
using ML.VehicleInventory.Application.Interfaces;
using VehicleInventory.Domain.Entities;
using VehicleInventory.Domain.Enums;

namespace ML.VehicleInventory.Application.Services
{
    public class MLVehicleService
    {
        private readonly IVehicleRepository _repo;

        public MLVehicleService(IVehicleRepository repo)
        {
            _repo = repo;
        }

        // CreateVehicle
        public async Task<MLVehicleDto> CreateVehicleAsync(MLCreateVehicleDto dto)
        {
            var vehicle = new Vehicle(dto.VehicleCode, dto.LocationId, dto.VehicleType);
            await _repo.AddAsync(vehicle);

            return ToDto(vehicle);
        }

        // GetVehicleById
        public async Task<MLVehicleDto?> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _repo.GetByIdAsync(id);
            if (vehicle == null) return null;

            return ToDto(vehicle);
        }

        // GetAllVehicles
        public async Task<List<MLVehicleDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _repo.GetAllAsync();
            return vehicles.Select(ToDto).ToList();
        }

        // UpdateVehicleStatus
        public async Task<bool> UpdateVehicleStatusAsync(int id, VehicleStatus newStatus)
        {
            var vehicle = await _repo.GetByIdAsync(id);
            if (vehicle == null) return false;

            // calling domain behavior methods (did not set Status directly)
            switch (newStatus)
            {
                case VehicleStatus.Available:
                    // reserved: available requires explicit release
                    if (vehicle.Status == VehicleStatus.Reserved)
                        vehicle.ReleaseReservation();
                    else
                        vehicle.MarkAvailable();
                    break;

                case VehicleStatus.Reserved:
                    vehicle.MarkReserved();
                    break;

                case VehicleStatus.Rented:
                    vehicle.MarkRented();
                    break;

                case VehicleStatus.Serviced:
                    vehicle.MarkServiced();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(newStatus), "Unknown vehicle status.");
            }

            await _repo.UpdateAsync(vehicle);
            return true;
        }

        // DeleteVehicle
        public async Task<bool> DeleteVehicleAsync(int id)
        {
            var vehicle = await _repo.GetByIdAsync(id);
            if (vehicle == null) return false;

            await _repo.DeleteAsync(vehicle);
            return true;
        }

        private static MLVehicleDto ToDto(Vehicle v)
        {
            return new MLVehicleDto
            {
                Id = v.Id,
                VehicleCode = v.VehicleCode,
                LocationId = v.LocationId,
                VehicleType = v.VehicleType,
                Status = v.Status
            };
        }
    }
}
