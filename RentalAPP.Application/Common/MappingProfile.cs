using AutoMapper;
using RentalAPP.Application.Cars.Dto;
using RentalAPP.Application.Customer.Dto;
using RentalAPP.Application.Rental.Dto;
using RentalAPP.Domain.Entities;

namespace RentalAPP.Application.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CarEntity, CarDto>();
        CreateMap<CustomerEntity, CustomerDto>();
        CreateMap<RentalEntity, RentalDto>();
    }
}
