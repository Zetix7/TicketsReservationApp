namespace TicketsReservation.ApplicationServices.API.Domain.Models;

public class Screening
{
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
    public int RoomId { get; set; }
    public Room? Room { get; set; }
    public List<Reservation>? Reservations { get; set; }
    public DateTime DisplayDate { get; set; }
}
