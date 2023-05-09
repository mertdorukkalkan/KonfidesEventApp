using Business.Utils;
using Core.Business.DTOs.Event;

namespace Business.Abstract;

public interface IEventService : ICrudEntityService<EventGetDto,EventCreateDto,EventUpdateDto>
{
    
}