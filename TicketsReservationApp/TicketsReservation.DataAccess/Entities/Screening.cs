namespace TicketsReservation.DataAccess.Entities;

public class Screening : EntityBase
{
    public int MovieId { get; set; }
    public int RoomId { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
}
