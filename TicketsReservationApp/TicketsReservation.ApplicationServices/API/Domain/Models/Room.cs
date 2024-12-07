namespace TicketsReservation.ApplicationServices.API.Domain.Models;

public class Room
{
    public List<Screening>? Screenings { get; set; }
    public bool IsScreen3d { get; set; }
    public int PremiumSeatsCount { get; set; }
    public int RegularSeatsCount { get; set; }
}
