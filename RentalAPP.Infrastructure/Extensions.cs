using RentalAPP.Infrastructure.IRepositories;
using RentalAPP.Infrastructure.Persistence;
using RentalAPP.Infrastructure.Persistence.Base;
using RentalAPP.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RentalAPP.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();
        services.AddDbContext<RentalDbContext>(options =>
            options.UseSqlite("Data Source=car_rental.db"));

        return services;
    }
}
  