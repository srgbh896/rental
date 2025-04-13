using RentalAPP.Domain.Entities;
using RentalAPP.Infrastructure.IRepositories;
using RentalAPP.Infrastructure.Persistence;
using RentalAPP.Infrastructure.Persistence.Base;
using Microsoft.EntityFrameworkCore;

namespace RentalAPP.Infrastructure.Repositories;

public class RentalRepository(RentalDbContext context) : BaseRepository<RentalEntity>(context), IRentalRepository
{
    public async Task<IEnumerable<RentalEntity>> GetByCustomerAsync(int customerId)
    {
        return await _dbSet.Where(r => r.CustomerId == customerId)
                           .Include(r => r.Car)
                           .ToListAsync();
    }
}
