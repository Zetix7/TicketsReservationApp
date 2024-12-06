using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Movies;

public class GetMovieByIdRequest : IRequest<GetMovieByIdResponse>
{
    public int Id { get; set; }
}
