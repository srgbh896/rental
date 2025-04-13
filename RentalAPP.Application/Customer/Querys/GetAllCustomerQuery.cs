using AutoMapper;
using RentalAPP.Application.Customer.Dto;
using RentalAPP.Infrastructure.IRepositories;
using MediatR;

namespace RentalAPP.Application.Customer.Querys;

public record GetAllCustomerQuery() : IRequest<IEnumerable<CustomerDto>>;

public class GetAllCustomerHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        var cars = await _customerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerDto>>(cars);
    }
}
