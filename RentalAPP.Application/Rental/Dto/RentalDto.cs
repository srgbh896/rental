namespace RentalAPP.Application.Rental.Dto;

public class RentalDto
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public int CustomerId { get; set; }

    public DateTime RentDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public decimal PaidAmount { get; set; }
    public decimal? ExtraCharge { get; set; }
}
