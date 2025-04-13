using RentalAPP.Domain.Base;
using RentalAPP.Domain.Enums;

namespace RentalAPP.Domain.Entities;

public sealed class CarEntity : BaseEntity
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Stock {  get; set; }
    public CarType Type { get; set; }
    public decimal BasePricePerDay { get; set; }
}
