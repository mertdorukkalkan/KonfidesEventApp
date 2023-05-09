using Business.Utils;
using Core.Business.DTOs.Ticket;
using Core.Utils.Results;

namespace Business.Abstract;

public interface ITicketService : ICrudEntityService<TicketGetDto,TicketCreateDto,TicketCreateDto>
{
    public Task<IDataResult<TicketGetDto>>  TicketCheck(string code);

    public Task<IDataResult<ICollection<TicketGetDto>>> GetUserTickets();
}