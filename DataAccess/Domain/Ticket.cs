using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;
using Domain;

namespace DataAccess.Domain;

public class Ticket : BaseEntity
{
    public string Code { get; set; }
    
    [ForeignKey("ApplicationUser")]
    public int UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    
    public int Price { get; set; } = 0;
    
    [ForeignKey("Event")]
    public int EventId { get; set; }
    public Event Event { get; set; }
}