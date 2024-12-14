using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Clients;

public class UpdateClientByIdRequest : IRequest<UpdateClientByIdResponse>
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
