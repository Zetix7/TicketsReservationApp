using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.DataAccess.Entities;

public class Movie : EntityBase
{
    public List<Screening>? Screenings { get; set; }

    [Required]
    [MaxLength(150)]
    public string? Title { get; set; }

    public int Duration { get; set; }
}
