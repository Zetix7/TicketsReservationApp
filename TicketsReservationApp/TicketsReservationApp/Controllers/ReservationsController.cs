using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketsReservation.ApplicationServices.API.Domain.Reservations;

namespace TicketsReservation.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllReservations([FromQuery] GetReservationsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetReservationById([FromRoute] int id)
    {
        var request = new GetReservationByIdRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddReservation([FromBody] AddReservationRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateReservationById([FromRoute] int id, [FromBody] UpdateReservationByIdRequest request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
