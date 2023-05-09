using Business.Utils;
using Core.Business.DTOs.Event;
using Core.Utils.Results;

namespace Business.Abstract;

public interface IEventService : ICrudEntityService<EventGetDto,EventCreateDto,EventUpdateDto>
{
    public Task<IDataResult<ICollection<EventGetDto>>> GetUserEvents();
}