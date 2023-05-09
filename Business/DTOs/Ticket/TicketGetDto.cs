namespace Core.Business.DTOs.Ticket;

public class TicketGetDto : TicketCreateDto,IEntityGetDto
{
    public int Id { get; set; }
    public string  FirstName { get; set; }
    public string LastName { get; set; }
    public string EventName { get; set; }

    public string TicketCode { get; set; }
}