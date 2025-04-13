using AutoMapper;
using RentalAPP.Application.Cars.Dto;
using RentalAPP.Infrastructure.IRepositories;
using MediatR;

namespace RentalAPP.Application.Cars.Querys;

public record GetAllCarQuery() : IRequest<IEnumerable<CarDto>>;

public class GetAllCarsQueryHandler(ICarRepository carRepository, IMapper mapper) : IRequestHandler<GetAllCarQuery, IEnumerable<CarDto>>
{
    private readonly ICarRepository _carRepository = carRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<CarDto>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CarDto>>(cars);
    }
}
