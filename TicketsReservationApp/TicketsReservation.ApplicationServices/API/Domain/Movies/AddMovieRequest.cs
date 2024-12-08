using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Movies;

public class AddMovieRequest : IRequest<AddMovieResponse>
{
    public string? Title { get; set; }
    public int Duration { get; set; }
}
