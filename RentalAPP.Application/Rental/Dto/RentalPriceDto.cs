using RentalAPP.Domain.Entities;

namespace RentalAPP.Application.Rental.Dto;

public class RentalPriceDto
{
    public int Days { get; set; }

    public int CarId { get; set; }

    public decimal PricePerDay { get; set; }

    public decimal TotalPrice { get; set; }
}