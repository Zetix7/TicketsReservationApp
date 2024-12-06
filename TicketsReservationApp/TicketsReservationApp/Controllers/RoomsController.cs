using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketsReservation.ApplicationServices.API.Domain.Rooms;

namespace TicketsReservation.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllRooms([FromQuery] GetRoomsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    [Route("id")]
    public async Task<IActionResult> GetRoomById([FromQuery] GetRoomByIdRequest request, int id)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
