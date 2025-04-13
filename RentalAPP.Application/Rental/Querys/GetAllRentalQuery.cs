using AutoMapper;
using RentalAPP.Application.Rental.Dto;
using RentalAPP.Infrastructure.IRepositories;
using MediatR;

namespace RentalAPP.Application.Rental.Querys;

public record GetAllRentalQuery() : IRequest<IEnumerable<RentalDto>>;

public class GetAllRentalQueryHandler(IRentalRepository rentalRepository, IMapper mapper) : IRequestHandler<GetAllRentalQuery, IEnumerable<RentalDto>>
{
    private readonly IRentalRepository _rentalRepository = rentalRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<RentalDto>> Handle(GetAllRentalQuery request, CancellationToken cancellationToken)
    {
        var cars = await _rentalRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<RentalDto>>(cars);
    }
}
