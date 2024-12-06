using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.ApplicationServices.API.Domain.Models;

public class Client
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
