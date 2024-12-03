using System.Runtime.InteropServices;

namespace TicketsReservation.DataAccess.Entities;

public class Reservation : EntityBase
{
    public int ClientId { get; set; }
    public int ScreeningId { get; set; }
    public char RowLetterSeatPlace { get; set; }
    public int NumberSeatPlace { get; set; }
    public string? PlaceType { get; set; }
    public decimal Price { get; set; }
}
