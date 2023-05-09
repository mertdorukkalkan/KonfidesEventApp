namespace Core.Business.DTOs.Ticket;

public class TicketGetDto : TicketCreateDto,IEntityGetDto
{
    public int Id { get; set; }
}