using AutoMapper;
using RentalAPP.Application.Rental.Dto;
using RentalAPP.Domain.DomainServices;
using RentalAPP.Domain.Entities;
using RentalAPP.Infrastructure.IRepositories;
using MediatR;

namespace RentalAPP.Application.Rental.Commands;

public record ReturnRentalCommand(int RentalId, DateTime ReturnDate) : IRequest<RentalDto>;

public class ReturnRentalCommandHandler(IRentalRepository rentalRepository, ICarRepository carRepository, IMapper mapper) : IRequestHandler<ReturnRentalCommand, RentalDto>
{
    private readonly IRentalRepository _rentalRepository = rentalRepository;
    private readonly ICarRepository _carRepository = carRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<RentalDto> Handle(ReturnRentalCommand request, CancellationToken cancellationToken)
    {
        RentalEntity rental = await _rentalRepository.GetByIdAsync(request.RentalId)
                     ?? throw new Exception("Rental not found");

        var car = await _carRepository.GetByIdAsync(rental.CarId)
                  ?? throw new Exception("Car not found");

        if (rental.ReturnDate is not null)
            throw new Exception("This rental has already been returned.");

        var extraDays = (request.ReturnDate - rental.EndDate).Days;
        if (extraDays > 0)
        {
            var extraCharge = RentalDomainService.CalculateExtraCharge(car) * extraDays;
            rental.ExtraCharge = extraCharge;
        }

        rental.ReturnDate = request.ReturnDate;

        await _rentalRepository.SaveChangesAsync();
        return _mapper.Map<RentalDto>(rental);
    }
}
