using RentalAPP.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace RentalAPP.Domain.Entities;

public sealed class RentalEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public int CarId { get; set; }
    public CarEntity Car { get; set; }

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; }

    public DateTime RentDate { get; set; }
    public DateTime EndDate{ get; set; }
    public DateTime? ReturnDate { get; set; }

    public decimal PaidAmount { get; set; }
    public decimal? ExtraCharge { get; set; }
}
