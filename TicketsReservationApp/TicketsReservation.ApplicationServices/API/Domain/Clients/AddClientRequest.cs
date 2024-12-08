using MediatR;
using System.Net.Sockets;

namespace TicketsReservation.ApplicationServices.API.Domain.Clients;

public class AddClientRequest : IRequest<AddClientResponse>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
