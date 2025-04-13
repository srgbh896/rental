using RentalAPP.Application.Customer.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RentalAPP.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// GetAll Customers
    /// </summary>
    /// <returns>List of CustomerDto</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCustomerQuery());
        return Ok(result);
    }
}
