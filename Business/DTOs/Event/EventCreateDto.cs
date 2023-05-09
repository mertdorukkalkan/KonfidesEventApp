using Core.Business.DTOs.Address;

namespace Core.Business.DTOs.Event;

public class EventCreateDto : AddressCreateDto,IDto
{
    public string EventName { get; set; }
    public DateTime DateTime { get; set; }
    public int Quota { get; set; }
    public string EventDescription { get; set; }
    public int? CategoryId { get; set; }
    
    
}