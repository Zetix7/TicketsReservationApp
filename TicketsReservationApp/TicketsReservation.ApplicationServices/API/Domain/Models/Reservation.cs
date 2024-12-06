namespace TicketsReservation.ApplicationServices.API.Domain.Models;

public class Reservation
{
    public int ClientId { get; set; }
    public Client? Client { get; set; }
    public int ScreeningId { get; set; }
    public Screening? Screening { get; set; }
    public char RowLetterSeatPlace { get; set; }
    public int NumberSeatPlace { get; set; }
    public bool IsPremiumSeatPlace { get; set; }
    public decimal Price { get; set; }
}
