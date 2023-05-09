namespace Core.Business.DTOs.Ticket;

public class TicketCreateDto : IDto
{
    public string Code { get; set; }
    public int UserId { get; set; }
    public int Price { get; set; } = 0;
    public int EventId { get; set; }
    
}