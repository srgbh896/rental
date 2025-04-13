using RentalAPP.Domain.Entities;
using RentalAPP.Domain.Enums;
using RentalAPP.Infrastructure.IRepositories;
using RentalAPP.Infrastructure.Persistence;
using RentalAPP.Infrastructure.Persistence.Base;
using Microsoft.EntityFrameworkCore;

namespace RentalAPP.Infrastructure.Repositories;

public class CarRepository(RentalDbContext context) : BaseRepository<CarEntity>(context), ICarRepository
{
    public async Task<IEnumerable<CarEntity>> GetByTypeAsync(CarType type)
    {
        return await _dbSet.Where(c => c.Type == type).ToListAsync();
    }
}
