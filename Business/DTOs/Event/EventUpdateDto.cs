namespace Core.Business.DTOs.Event;

public class EventUpdateDto : IDto
{
    public string EventName { get; set; }
    public DateTime DateTime { get; set; }
    public int Quota { get; set; }
    public string EventDescription { get; set; }
    public int? CategoryId { get; set; }
    public int? AddressId { get; set; }
    public int? StatusId { get; set; }
    
}