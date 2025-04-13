using RentalAPP.Domain.Entities;
using RentalAPP.Infrastructure.Persistence.Base;

namespace RentalAPP.Infrastructure.IRepositories;

public interface IRentalRepository : IBaseRepository<RentalEntity>
{
    Task<IEnumerable<RentalEntity>> GetByCustomerAsync(int customerId);
}
