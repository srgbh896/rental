namespace RentalAPP.Application.Cars.Dto;

public class CarDto
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal BasePricePerDay { get; set; }
    public int Stock {  get; set; }
}
