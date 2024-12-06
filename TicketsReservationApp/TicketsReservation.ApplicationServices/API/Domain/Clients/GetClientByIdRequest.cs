using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Clients;

public class GetClientByIdRequest : IRequest<GetClientByIdResponse>
{
    public int Id { get; set; }
}
