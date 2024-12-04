using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.DataAccess.Entities;

public class Client : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string? LastName { get; set; }
}
