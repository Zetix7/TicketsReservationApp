﻿using MediatR;
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
    [Route("{id}")]
    public async Task<IActionResult> GetRoomById([FromRoute] int id)
    {
        var request = new GetRoomByIdRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddRoom([FromBody] AddRoomRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateRoomById([FromRoute] int id, [FromBody] UpdateRoomByIdRequest request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
