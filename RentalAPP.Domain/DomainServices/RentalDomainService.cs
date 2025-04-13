using RentalAPP.Domain.Entities;
using RentalAPP.Domain.Enums;

namespace RentalAPP.Domain.DomainServices;

public class RentalDomainService
{
    public static decimal CalculateRentalPrice(CarEntity car, int days)
    {
        var pricePerDay = car.BasePricePerDay;

        return car.Type switch
        {
            CarType.Premium => pricePerDay * days,
            CarType.SUV => CalculateSuvPrice(pricePerDay, days),
            CarType.Small => CalculateSmallPrice(pricePerDay, days),
            _ => 0
        };
    }

    private static decimal CalculateSuvPrice(decimal basePrice, int days)
    {
        if (days <= 7) return basePrice * days;
        if (days <= 30) return days * basePrice * 0.8m;
        return days * basePrice * 0.5m;
    }

    private static decimal CalculateSmallPrice(decimal basePrice, int days)
    {
        if (days <= 7) return basePrice * days;
        return (days * basePrice * 0.6m);
    }

    public static decimal CalculateExtraCharge(CarEntity car)
    {
        var price = car.BasePricePerDay;
        return car.Type switch
        {
            CarType.Premium => price + price * 0.2m,
            CarType.SUV => price + price * 0.6m,
            CarType.Small => price + price * 0.3m,
            _ => 0
        };
    }
    
}
