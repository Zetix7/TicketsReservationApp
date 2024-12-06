using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Screenings;

public class GetScreeningByIdRequest : IRequest<GetScreeningByIdResponse>
{
    public int Id { get; set; }
}
