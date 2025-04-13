using RentalAPP.Domain.Entities;
using RentalAPP.Infrastructure.Persistence.Base;

namespace RentalAPP.Infrastructure.IRepositories;

public interface ICustomerRepository : IBaseRepository<CustomerEntity>
{
    Task<CustomerEntity?> GetWithRentalsAsync(int id);
}

