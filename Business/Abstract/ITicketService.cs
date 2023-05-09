using Business.Utils;
using Core.Business.DTOs.Ticket;
using Core.Utils.Results;

namespace Business.Abstract;

public interface ITicketService : ICrudEntityService<TicketGetDto,TicketCreateDto,TicketCreateDto>
{
    public IDataResult<string> TicketCheck(string code);
}