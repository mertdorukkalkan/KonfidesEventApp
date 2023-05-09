using Business.DTOs.Address;

namespace Core.Business.DTOs.Event;

public class EventUpdateDto : AddressCreateDto,IDto
{
    public int Quota { get; set; }

}