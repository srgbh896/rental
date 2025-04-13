using RentalAPP.Domain.Entities;
using RentalAPP.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace RentalAPP.Infrastructure.Persistence;

public static class DbInit
{
    public static void Initialize(RentalDbContext context)
    {
        //context.Database.Migrate();

        // Seed cars
        if (!context.Cars.Any())
        {
            var cars = new List<CarEntity>
            {
                new () { Brand = "BMW", Model = "M5", Type = CarType.Premium, BasePricePerDay = 300, Stock = 3 },
                new () { Brand = "Toyota", Model = "RAV4", Type = CarType.SUV, BasePricePerDay = 150, Stock = 2 },
                new () { Brand = "Ford", Model = "Fiesta", Type = CarType.Small, BasePricePerDay = 50, Stock = 10 },
                new () { Brand = "Audi", Model = "Q7", Type = CarType.SUV, BasePricePerDay = 150, Stock = 4 },
                new () { Brand = "Peugeot", Model = "208", Type = CarType.Small, BasePricePerDay = 50, Stock = 1 },
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        if (!context.Customers.Any())
        {
            // Seed Customers
            var customers = new CustomerEntity[]
            {
                new () { FullName = "John Doe", LoyaltyPoints = 2 },
                new () { FullName = "Jane Smith", LoyaltyPoints = 32 }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        if (!context.Rentals.Any())
        {
            // Seed Rentals
            var rentals = new RentalEntity[]
            {
                    new () { CarId = 1, CustomerId = 1, RentDate = DateTime.Now.AddDays(-5), ReturnDate = DateTime.Now, PaidAmount = 100, ExtraCharge = 0 },
                    new () { CarId = 2, CustomerId = 2, RentDate = DateTime.Now.AddDays(-10), ReturnDate = DateTime.Now.AddDays(1), PaidAmount = 600, ExtraCharge = 30 }
            };

            context.Rentals.AddRange(rentals);
            context.SaveChanges();
        }
    }
}
