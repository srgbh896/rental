using RentalAPP.Domain.Entities;
using RentalAPP.Infrastructure.IRepositories;
using RentalAPP.Infrastructure.Persistence;
using RentalAPP.Infrastructure.Persistence.Base;
using Microsoft.EntityFrameworkCore;

namespace RentalAPP.Infrastructure.Repositories;

public class CustomerRepository(RentalDbContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{
    public async Task<CustomerEntity?> GetWithRentalsAsync(int id)
    {
        return await _dbSet.Include(c => c.Rentals)
                           .FirstOrDefaultAsync(c => c.Id == id);
    }
}