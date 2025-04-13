using RentalAPP.Application.Cars.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RentalAPP.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCarQuery());
        return Ok(result); // Devuelve IEnumerable<CarDto>
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetById(int id)
    //{
    //    var result = await _mediator.Send(new GetCarByIdQuery(id));
    //    return result is not null ? Ok(result) : NotFound();
    //}

    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] CreateCarCommand command)
    //{
    //    var dto = await _mediator.Send(command);
    //    return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update(int id, [FromBody] UpdateCarCommand command)
    //{
    //    if (id != command.Id)
    //        return BadRequest("ID del path no coincide con el del comando.");

    //    var result = await _mediator.Send(command);
    //    return result ? NoContent() : NotFound();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var result = await _mediator.Send(new DeleteCarCommand(id));
    //    return result ? NoContent() : NotFound();
    //}
}
