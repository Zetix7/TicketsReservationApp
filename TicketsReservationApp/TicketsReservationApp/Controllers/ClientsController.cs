﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketsReservation.ApplicationServices.API.Domain.Clients;

namespace TicketsReservation.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllClients([FromQuery] GetClientsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetClientById([FromRoute] int id)
    {
        var request = new GetClientByIdRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddClient([FromBody] AddClientRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateClientById([FromRoute] int id, [FromBody] UpdateClientByIdRequest request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
