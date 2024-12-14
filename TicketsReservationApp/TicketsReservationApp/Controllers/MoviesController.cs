using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketsReservation.ApplicationServices.API.Domain.Movies;

namespace TicketsReservation.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllMovies([FromQuery] GetMoviesRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetMovieById([FromRoute] int id)
    {
        var request = new GetMovieByIdRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddMovie([FromBody] AddMovieRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateMovieById([FromRoute] int id, [FromBody] UpdateMovieByIdRequest request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
