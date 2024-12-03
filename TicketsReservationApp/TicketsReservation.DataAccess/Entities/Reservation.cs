namespace TicketsReservation.DataAccess.Entities;

public class Reservation : EntityBase
{
    public int ClientId { get; set; }
    public int ScreeningId { get; set; }
    public char SeatPlace { get; set; }
    public int RowPlace { get; set; }
    public string? PlaceType { get; set; }
}
