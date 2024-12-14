using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Movies;

public class UpdateMovieByIdRequest : IRequest<UpdateMovieByIdResponse>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int Duration { get; set; }
}
