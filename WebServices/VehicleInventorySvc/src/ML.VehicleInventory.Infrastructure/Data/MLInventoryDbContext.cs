using Microsoft.EntityFrameworkCore;
using VehicleInventory.Domain.Entities;

namespace ML.VehicleInventory.Infrastructure.Data
{
    public class MLInventoryDbContext : DbContext
    {
        public MLInventoryDbContext(DbContextOptions<MLInventoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> MLVehicles => Set<Vehicle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("MLVehicles");

                entity.HasKey(v => v.Id);

                entity.Property(v => v.VehicleCode)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(v => v.VehicleType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(v => v.LocationId)
                    .IsRequired();

                // Status is enum: store as int by default
                entity.Property(v => v.Status)
                    .IsRequired();
            });
        }
    }
}
