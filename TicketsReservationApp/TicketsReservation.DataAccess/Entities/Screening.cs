using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.DataAccess.Entities;

public class Screening : EntityBase
{
    public int MovieId { get; set; }

    public Movie? Movie { get; set; }

    public int RoomId { get; set; }

    public Room? Room { get; set; }

    public List<Reservation>? Reservations { get; set; }

    [Required]
    public DateTime DisplayDate { get; set; }
}
