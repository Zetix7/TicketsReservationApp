using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.ApplicationServices.API.Domain.Models;

public class Room
{
    public bool IsScreen3d { get; set; }
    public int PremiumSeatsCount { get; set; }
    public int RegularSeatsCount { get; set; }
}
