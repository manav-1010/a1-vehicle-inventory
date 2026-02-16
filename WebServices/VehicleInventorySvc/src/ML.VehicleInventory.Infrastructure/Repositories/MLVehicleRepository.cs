using Microsoft.EntityFrameworkCore;
using ML.VehicleInventory.Application.Interfaces;
using ML.VehicleInventory.Infrastructure.Data;
using VehicleInventory.Domain.Entities;

namespace ML.VehicleInventory.Infrastructure.Repositories
{
    public class MLVehicleRepository : IVehicleRepository
    {
        private readonly MLInventoryDbContext _db;

        public MLVehicleRepository(MLInventoryDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            _db.MLVehicles.Add(vehicle);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Vehicle vehicle)
        {
            _db.MLVehicles.Remove(vehicle);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _db.MLVehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            return await _db.MLVehicles.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            _db.MLVehicles.Update(vehicle);
            await _db.SaveChangesAsync();
        }
    }
}
