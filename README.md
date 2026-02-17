# A1 – Vehicle Inventory Microservice

This is my Assignment 1 for the Vehicle Inventory microservice.  
It covers the **Inventory bounded context** of a car rental platform (only inventory stuff).

## What this service does

- Store vehicles for different locations
- Basic CRUD through a REST API
- Track vehicle status (Available / Reserved / Rented / Serviced)
- Enforce the status rules inside the Domain layer (not in controllers / EF)

## Architecture structure

The solution is split into 4 projects:

- **VehicleInventory.Domain**
  - `Vehicle` entity, enums, domain rules
  - No EF Core, no ASP.NET

- **ML.VehicleInventory.Application**
  - DTOs, repository interface, and the service (use cases)
  - No EF Core, no ASP.NET

- **ML.VehicleInventory.Infrastructure**
  - EF Core DbContext, repository implementation, migrations
  - No business rules

- **ML.VehicleInventory.WebAPI**
  - Controllers + DI setup + Swagger
  - Controllers stay thin (they call the application service)

## Domain rules (examples)

These are checked in the `Vehicle` entity:

- can’t rent a vehicle if it’s already rented
- can’t rent a reserved vehicle
- can’t rent a vehicle under service
- reserved → available needs an explicit release
- invalid status changes throw a domain exception

The API catches domain exceptions and returns **400 Bad Request** with a simple error message.

## How to run

1. Open the solution in Visual Studio
2. Set **ML.VehicleInventory.WebAPI** as the Startup Project
3. Run it
4. Swagger is available at `/swagger`

### Database

EF Core migrations are used. By default it connects to LocalDB using the connection string in:

- `ML.VehicleInventory.WebAPI/appsettings.json`

## API endpoints

- GET `/api/vehicles`
- GET `/api/vehicles/{id}`
- POST `/api/vehicles`
- PUT `/api/vehicles/{id}/status`
- DELETE `/api/vehicles/{id}`

## Known limitations

- Swagger shows enum values as integers by default
- No auth (not part of A1)
