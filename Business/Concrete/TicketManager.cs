using AutoMapper;
using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Ticket;
using Core.Utils.Results;
using DataAccess;
using DataAccess.Domain;

namespace Business.Concrete;

public class TicketManager : CrudEntityManager<Ticket,TicketGetDto,TicketCreateDto,TicketCreateDto> , ITicketService
{
    public TicketManager(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public IDataResult<string> TicketCheck(string code)
    {
        throw new NotImplementedException();
    }
}