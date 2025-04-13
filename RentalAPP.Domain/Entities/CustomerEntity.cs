using RentalAPP.Domain.Base;

namespace RentalAPP.Domain.Entities;

public sealed class CustomerEntity : BaseEntity
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int LoyaltyPoints { get; set; }

    public ICollection<RentalEntity> Rentals { get; set; } = [];
}
