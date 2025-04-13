using RentalAPP.Application.Cars.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RentalAPP.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Get all cars
    /// </summary>
    /// <returns>List of CarDto</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCarQuery());
        return Ok(result);
    }
}
