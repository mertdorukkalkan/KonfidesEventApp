using System.Security.Claims;
using AutoMapper;
using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Event;
using Core.DataAccess;
using Core.Utils.Results;
using DataAccess;
using DataAccess.Domain;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete;

public class EventManager : CrudEntityManager<Event,EventGetDto,EventCreateDto,EventUpdateDto>, IEventService
{
    private IEntityRepository<Address> _addressRepository;
    private UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _accessor;
    public EventManager(IUnitOfWorks unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor) : base(unitOfWork, mapper)
    {
        _userManager = userManager;
        _accessor = accessor;
        _addressRepository = UnitOfWork.GenerateRepository<Address>();
    }

    public override async Task<IDataResult<EventGetDto>> AddAsync(EventCreateDto input)
    {
        var eEvent = Mapper.Map<EventCreateDto, Event>(input);
        var address = Mapper.Map<EventCreateDto, Address>(input);
        
        await UnitOfWork.BeginTransactionAsync();
        try
        {
            var claims = GetUser();
            var user = await _userManager.FindByNameAsync(claims.Identity.Name);
            eEvent.ApplicationUser = user;
            await _addressRepository.AddAsync(address);
            eEvent.AddressId = address.Id;
            eEvent.StatusId = 1;
            await BaseEntityRepository.AddAsync(eEvent);
            await UnitOfWork.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            await UnitOfWork.RollbackTransactionAsync();
            return new ErrorDataResult<EventGetDto>(ex.Message);
        }

        return await GetByIdAsync(eEvent.Id);
    }

    public override async Task<IDataResult<EventGetDto>> UpdateAsync(int id, EventUpdateDto input)
    {
        
        var entity = await BaseEntityRepository.GetAsync(x => x.Id == id);
        var address = await _addressRepository.GetAsync(x => x.Id == input.AddressId);

        if (entity == null)
        {
            return new ErrorDataResult<EventGetDto>($"'{id}' id'li {typeof(Event).Name} entitysi bulunamad�.");
        }
        if (address == null)
        {
            return new ErrorDataResult<EventGetDto>($"'{id}' id'li {typeof(Address).Name} entitysi bulunamad�.");
        }

        var updatedEntity = Mapper.Map(input, entity);
        updatedEntity.UpdatedTime = DateTime.Now;
        var updatedAddress = Mapper.Map(input, address);
        updatedAddress.UpdatedTime = DateTime.Now;

        try
        {
            await BaseEntityRepository.UpdateAsync(updatedEntity);
            await _addressRepository.UpdateAsync(updatedAddress);
        }
        catch (Exception ex)
        {
            return new ErrorDataResult<EventGetDto>(ex.Message);
        }

        return await GetByIdAsync(id);
    }
    public ClaimsPrincipal GetUser() {
        return _accessor?.HttpContext?.User;
    }
    public override async Task<IDataResult<ICollection<EventGetDto>>> GetAllAsync()
    {
        var entities = await BaseEntityRepository.GetListWithIncludeAsync(null,x=>x.Address,y=>y.Category,z=>z.Status,t=>t.ApplicationUser);
        var entityDtos = Mapper.Map<List<Event>, List<EventGetDto>>(entities.ToList());
        return new SuccessDataResult<ICollection<EventGetDto>>(entityDtos);
    }

    public override async Task<IDataResult<EventGetDto>> GetByIdAsync(int id)
    {
        var eEvent = await BaseEntityRepository.GetWithIncludeAsync(c => c.Id == id, x=>x.Address,y=>y.Category,z=>z.Status,t=>t.ApplicationUser);
        if (eEvent == null)
        {
            return new ErrorDataResult<EventGetDto>($"'{id}' id'li Event entitysi bulunamadı.");
        }
            
        var eventGetDto = Mapper.Map<Event, EventGetDto>(eEvent);
        return new SuccessDataResult<EventGetDto>(eventGetDto);
    }
}