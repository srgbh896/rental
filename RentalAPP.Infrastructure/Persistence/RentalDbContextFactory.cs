namespace RentalAPP.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class RentalDbContextFactory : IDesignTimeDbContextFactory<RentalDbContext>
{
    public RentalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RentalDbContext>();
        optionsBuilder.UseSqlite("Data Source=car_rental.db");

        return new RentalDbContext(optionsBuilder.Options);
    }
}