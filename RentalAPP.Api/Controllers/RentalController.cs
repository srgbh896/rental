using RentalAPP.Application.Customer.Querys;
using RentalAPP.Application.Rental.Commands;
using RentalAPP.Application.Rental.Dto;
using RentalAPP.Application.Rental.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RentalAPP.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Get all rentals
    /// </summary>
    /// <returns>List of RentalDTO</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllRentalQuery());
        return Ok(result);
    }

    /// <summary>
    /// Check price
    /// </summary>
    /// <param name="carId"></param>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns>PriceDto</returns>
    [HttpGet("{carId:int}/calculate-price")]
    public async Task<IActionResult> CalculateRentalPrice(int carId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var query = new GetRentalPriceQuery
        {
            CarId = carId,
            StartDate = startDate,
            EndDate = endDate
        };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Create new rental
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<RentalDto>> CreateRental([FromBody] CreateRentalCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateRental), new { id = result.Id }, result);
    }

    /// <summary>
    /// Return vehicle
    /// </summary>
    [HttpPut("{id}/return")]
    public async Task<ActionResult<RentalDto>> ReturnRental(int id, [FromQuery] DateTime returnDate)
    {
        var command = new ReturnRentalCommand(id, returnDate);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
