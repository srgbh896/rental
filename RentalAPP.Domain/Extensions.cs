using Microsoft.Extensions.DependencyInjection;

namespace RentalAPP.Domain;

public static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}