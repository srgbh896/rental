using RentalAPP.Domain.Entities;
using RentalAPP.Domain.Enums;
using RentalAPP.Infrastructure.Persistence.Base;

namespace RentalAPP.Infrastructure.IRepositories;

public interface ICarRepository : IBaseRepository<CarEntity>
{
    Task<IEnumerable<CarEntity>> GetByTypeAsync(CarType type);
}
