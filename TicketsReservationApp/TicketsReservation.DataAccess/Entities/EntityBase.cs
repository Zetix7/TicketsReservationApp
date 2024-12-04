using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.DataAccess.Entities;

public abstract class EntityBase : IEntity
{
    [Key]
    public int Id { get; set; }
}
