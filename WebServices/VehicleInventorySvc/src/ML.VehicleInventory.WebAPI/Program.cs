using Microsoft.EntityFrameworkCore;
using ML.VehicleInventory.Application.Services;
using ML.VehicleInventory.Application.Interfaces;
using ML.VehicleInventory.Infrastructure.Data;
using ML.VehicleInventory.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MLInventoryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MLInventoryDb"));
});

builder.Services.AddScoped<IVehicleRepository, MLVehicleRepository>();
builder.Services.AddScoped<MLVehicleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
