namespace TicketsReservation.DataAccess.Entities;

public class Room : EntityBase
{
    public string? RoomType { get; set; }
    public int PremiumSeatsAmount { get; set; }
    public int RegularSeatsAmount { get; set; }
}
