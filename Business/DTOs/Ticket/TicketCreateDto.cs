namespace Core.Business.DTOs.Ticket;

public class TicketCreateDto : IDto
{
    public int Price { get; set; } = 0;
    public int EventId { get; set; }
    
}