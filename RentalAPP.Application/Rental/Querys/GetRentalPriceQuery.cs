using AutoMapper;
using RentalAPP.Application.Rental.Dto;
using RentalAPP.Domain.DomainServices;
using RentalAPP.Infrastructure.IRepositories;
using MediatR;

namespace RentalAPP.Application.Rental.Querys;

public record GetRentalPriceQuery() : IRequest<RentalPriceDto>
{
    public int CarId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class GetRentalPriceQueryHandler(ICarRepository carRepository, IMapper mapper) : IRequestHandler<GetRentalPriceQuery, RentalPriceDto>
{
    private readonly ICarRepository _carRepository = carRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<RentalPriceDto> Handle(GetRentalPriceQuery request, CancellationToken cancellationToken)
    {
        var totalDays = (int)(request.EndDate - request.StartDate).TotalDays;
        RentalPriceDto result = new();
        var car = await _carRepository.GetByIdAsync(request.CarId);

        result.TotalPrice = RentalDomainService.CalculateRentalPrice(car, totalDays);
        result.PricePerDay = result.TotalPrice / totalDays;
        return result;
    }
}
