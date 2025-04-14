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

public class GetRentalPriceQueryHandler(ICarRepository carRepository) : IRequestHandler<GetRentalPriceQuery, RentalPriceDto>
{
    private readonly ICarRepository _carRepository = carRepository;

    public async Task<RentalPriceDto> Handle(GetRentalPriceQuery request, CancellationToken cancellationToken)
    {
        var totalDays = (int)(request.EndDate - request.StartDate).TotalDays;
        if (totalDays <= 0) throw new Exception("Rental must be at least one day."); 
        RentalPriceDto result = new();
        var car = await _carRepository.GetByIdAsync(request.CarId)
          ?? throw new Exception("Car not found");
        result.TotalPrice = RentalDomainService.CalculateRentalPrice(car, totalDays);
        result.PricePerDay = result.TotalPrice / totalDays;
        result.Days = totalDays;
        return result;
    }
}
