
# Car Rental API

## Objective

The goal is to create an API that supports:

- Car inventory management
- Rental price calculation
- Tracking customer loyalty points

Due to time constraints (limited to ~4 hours), the focus has been placed on clean architecture, domain modeling, extensibility, and implementing core features with realistic behavior.

---

## Tech Stack

- **.NET 8**
- **Entity Framework Core + SQLite (embedded)**
- **CQRS + MediatR**
- **AutoMapper**
- **Minimal seeding with `DbContext`**
- **Swagger for API testing**
- **Vertical Slice architecture by feature**

---

## Key Decisions

### What I Focused On

- **Domain Modeling**: Clear separation of concerns between entities like `Car`, `Rental`, and `Customer`, each with responsibility and behaviors (e.g., `RentalPriceCalculator`).
- **CQRS + MediatR**: All operations are represented with Commands/Queries and their corresponding Handlers, making the codebase easier to scale and test.
- **AutoMapper**: Used to project domain entities into DTOs, keeping concerns well-separated.
- **SQLite (embedded)**: Simplifies running the app locally with no external dependencies.
- **Data seeding**: Ensures the app is usable out of the box for testing core features.

### What I Didn’t Focus On

- ❌ Authorization & authentication
- ❌ Unit/integration testing
- ❌ Full CRUD for all entities
- ❌ Full error handling/validation

---
## Features Implemented

- [x] Create rental
- [x] Return rental (calculates extra charges + updates loyalty points)
- [x] Calculate rental price based on car type and date range
- [x] Seed initial data for Cars, Customers, and Rentals
- [x] SQLite database with EF Core migration
- [x] Swagger UI enabled

---

## How to Run

### 1. Clone the repository

```bash
git clone https://github.com/srgbh896/rental.git
cd rental
```

### 2. Restore & build

```bash
dotnet restore
dotnet build
```

### 3. Apply migrations & run

```bash
cd RentalApp.Api
dotnet ef database update
dotnet run
```

## Author

Sergio Barrado Hernández  
Senior Backend Developer (.NET)  
Salamanca, Spain
