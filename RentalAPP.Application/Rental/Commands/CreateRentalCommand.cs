using AutoMapper;
using RentalAPP.Application.Rental.Dto;
using RentalAPP.Domain.DomainServices;
using RentalAPP.Domain.Entities;
using RentalAPP.Domain.Enums;
using RentalAPP.Infrastructure.IRepositories;
using MediatR;

namespace RentalAPP.Application.Rental.Commands;

public record CreateRentalCommand(int CarId, int CustomerId, DateTime StartDate, DateTime EndDate)
    : IRequest<RentalDto>;

public class CreateRentalCommandHandler(
    IRentalRepository rentalRepository,
    ICarRepository carRepository,
    ICustomerRepository customerRepository,
    IMapper mapper) : IRequestHandler<CreateRentalCommand, RentalDto>
{
    private readonly IRentalRepository _rentalRepository = rentalRepository;
    private readonly ICarRepository _carRepository = carRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<RentalDto> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.CarId)
                  ?? throw new Exception("Car not found");

        var customer = await _customerRepository.GetByIdAsync(request.CustomerId)
                       ?? throw new Exception("Customer not found");

        var days = (request.EndDate - request.StartDate).Days;
        if (days <= 0) throw new Exception("Rental must be at least one day.");
        var price = RentalDomainService.CalculateRentalPrice(car, days);


        var rental = new RentalEntity
        {
            CarId = car.Id,
            CustomerId = customer.Id,
            RentDate = request.StartDate,
            EndDate = request.EndDate,
            PaidAmount = price
        };
        customer.LoyaltyPoints += GetLoyaltyPoints(car.Type);
        await _rentalRepository.AddAsync(rental);
        await _customerRepository.SaveChangesAsync();
        await _rentalRepository.SaveChangesAsync();
        return _mapper.Map<RentalDto>(rental);
    }

    private static int GetLoyaltyPoints(CarType carType)
        => carType switch { CarType.Small => 1, CarType.SUV => 3, CarType.Premium => 5, _ => throw new NotImplementedException() };
}
