using System.Security.Claims;
using AutoMapper;
using Business.Abstract;
using Business.Utils;
using Business.Utils.CurrentUserConfiguration;
using Core.Business.DTOs.Ticket;
using Core.DataAccess;
using Core.Utils.Results;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace Business.Concrete;

public class TicketManager : CrudEntityManager<Ticket,TicketGetDto,TicketCreateDto,TicketCreateDto> , ITicketService
{
    private IEntityRepository<Event> _eventRepository;
    private KonfidesAppUser _konfidesAppUser;
    
    public TicketManager(IUnitOfWorks unitOfWork, IMapper mapper, KonfidesAppUser konfidesAppUser) : base(unitOfWork, mapper)
    {
        _konfidesAppUser = konfidesAppUser;
        _eventRepository = UnitOfWork.GenerateRepository<Event>();
    }

    public override async Task<IDataResult<TicketGetDto>> AddAsync(TicketCreateDto input)
    {
        var ticket = Mapper.Map<TicketCreateDto, Ticket>(input);
        await UnitOfWork.BeginTransactionAsync();
        try
        {
        var checkTicket = await BaseEntityRepository.GetListWithIncludeAsync(x => x.EventId == input.EventId,Y=>Y.ApplicationUser);
        foreach (var check in checkTicket)
        {
            if (check.UserId == _konfidesAppUser.User.Id)
            {
                return new ErrorDataResult<TicketGetDto>("Bu Etkinlik için Biletiniz Var");
            }
            
        }
        
        var eEvent = await _eventRepository.GetAsync(x => x.Id == input.EventId);
        if (eEvent.UserId==_konfidesAppUser.User.Id)
        {
            return new ErrorDataResult<TicketGetDto>("Kullanıcı Kendi Etkinliğine Bilet Alamaz");
        }
            ticket.UserId = _konfidesAppUser.User.Id;
            ticket.TicketCode = _konfidesAppUser.User.Id.ToString() + ticket.EventId + RandomString();  
            await BaseEntityRepository.AddAsync(ticket);
            await UnitOfWork.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            await UnitOfWork.RollbackTransactionAsync();
            return new ErrorDataResult<TicketGetDto>(ex.Message);
        }

        return await GetByIdAsync(ticket.Id);
    }
    public override async Task<IDataResult<ICollection<TicketGetDto>>> GetAllAsync()
    {
        var entities = await BaseEntityRepository.GetListWithIncludeAsync(null,t=>t.ApplicationUser,x=>x.Event);
        var entityDtos = Mapper.Map<List<Ticket>, List<TicketGetDto>>(entities.ToList());
        return new SuccessDataResult<ICollection<TicketGetDto>>(entityDtos);
    }

    public override async Task<IDataResult<TicketGetDto>> GetByIdAsync(int id)
    {
        var ticket = await BaseEntityRepository.GetWithIncludeAsync(x => x.Id == id, t => t.ApplicationUser, x => x.Event);
        if (ticket == null)
        {
            return new ErrorDataResult<TicketGetDto>($"'{id}' id'li Event entitysi bulunamadı.");
        }
            
        var eventGetDto = Mapper.Map<Ticket, TicketGetDto>(ticket);
        return new SuccessDataResult<TicketGetDto>(eventGetDto);
    }

    public async Task<IDataResult<TicketGetDto>> TicketCheck(string code)
    {
        var ticket = await BaseEntityRepository.GetAsync(x => x.TicketCode == code);
        if (ticket == null)
        {
           return new ErrorDataResult<TicketGetDto>("Bilet bulunamadı");
        }

        return await GetByIdAsync(ticket.Id);
    }

    public async Task<IDataResult<ICollection<TicketGetDto>>> GetUserTickets()
    {
        var tickets = await BaseEntityRepository.GetListAsync(x => x.UserId == _konfidesAppUser.User.Id);
        var ticketDtos = Mapper.Map<List<Ticket>, List<TicketGetDto>>(tickets.ToList());
        return new SuccessDataResult<ICollection<TicketGetDto>>(ticketDtos);
        
    }
    public string RandomString()
    {
        Random r = new Random();
        var x = r.Next(0, 1000000);
        string s = x.ToString("000000");
        return s;
    }
}