using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.DataAccess.Entities;

public class Movie : EntityBase
{
    [Required]
    [MaxLength(150)]
    public string? Title { get; set; }
    public int Durtion { get; set; }
}
