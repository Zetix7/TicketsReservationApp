namespace TicketsReservation.DataAccess.Entities;

public class Room : EntityBase
{
    public string? RoomType { get; set; }
    public int PremiumSeatsCount { get; set; }
    public int RegularSeatsCount { get; set; }
}
