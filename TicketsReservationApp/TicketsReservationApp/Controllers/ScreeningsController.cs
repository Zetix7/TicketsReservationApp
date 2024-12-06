using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketsReservation.ApplicationServices.API.Domain.Screenings;

namespace TicketsReservation.Controllers;

[ApiController]
[Route("[controller]")]
public class ScreeningsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ScreeningsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllScreenings([FromQuery] GetScreeningsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    [Route("id")]
    public async Task<IActionResult> GetScreeningById([FromQuery] GetScreeningByIdRequest request, int id)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
