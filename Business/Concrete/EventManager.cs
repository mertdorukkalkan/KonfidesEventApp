using System.Security.Claims;
using AutoMapper;
using Business.Abstract;
using Business.Utils;
using Business.Utils.CurrentUserConfiguration;
using Core.Business.DTOs.Event;
using Core.DataAccess;
using Core.Utils.Results;
using DataAccess;
using Domain;
using IResult = Core.Utils.Results.IResult;

namespace Business.Concrete;

public class EventManager : CrudEntityManager<Event,EventGetDto,EventCreateDto,EventUpdateDto>, IEventService
{
    private IEntityRepository<Address> _addressRepository;
    private KonfidesAppUser _konfidesAppUser;
    public EventManager(IUnitOfWorks unitOfWork, IMapper mapper, KonfidesAppUser konfidesAppUser) : base(unitOfWork, mapper)
    {
        _konfidesAppUser = konfidesAppUser;
        _addressRepository = UnitOfWork.GenerateRepository<Address>();
    }

    public override async Task<IDataResult<EventGetDto>> AddAsync(EventCreateDto input)
    {
        var address = Mapper.Map<EventCreateDto, Address>(input);
        var eEvent = Mapper.Map<EventCreateDto, Event>(input);
        
        
        await UnitOfWork.BeginTransactionAsync();
        try
        {
            eEvent.ApplicationUser = _konfidesAppUser.User;
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
        
        var entity = await BaseEntityRepository.GetWithIncludeAsync(x => x.Id == id,y=>y.Address);

        if (entity == null)
        {
            return new ErrorDataResult<EventGetDto>($"'{id}' id'li {typeof(Event).Name} entitysi bulunamad�.");
        }

        if (entity.DateTime.Subtract(DateTime.Now).TotalDays < 5)
        {
            return new ErrorDataResult<EventGetDto>("5 günden az süre kaldığı için etkinlik güncellenemez ");
        }
        var updatedEntity = Mapper.Map(input, entity);
        entity.Address = Mapper.Map(input, entity.Address);
        updatedEntity.UpdatedTime = DateTime.Now;
        
        try
        {
            await BaseEntityRepository.UpdateAsync(updatedEntity);
            await _addressRepository.UpdateAsync(entity.Address);
        }
        catch (Exception ex)
        {
            return new ErrorDataResult<EventGetDto>(ex.Message);
        }

        return await GetByIdAsync(id);
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
    
    public async Task<IDataResult<ICollection<EventGetDto>>> GetUserEvents()
    {
        var events = await BaseEntityRepository.GetListAsync(x => x.UserId == _konfidesAppUser.User.Id);
        var eventGetDtos = Mapper.Map<List<Event>, List<EventGetDto>>(events.ToList());
        return new SuccessDataResult<ICollection<EventGetDto>>(eventGetDtos);
        
    }
    public override async Task<IResult> DeleteByIdAsync(int id)
    {
        var entity = await BaseEntityRepository.GetAsync(c => c.Id == id);
        if (entity.DateTime.Subtract(DateTime.Now).TotalDays < 5)
        {
            return new ErrorDataResult<EventGetDto>("5 günden az süre kaldığı için etkinlik silinemez ");
        }
        try
        {
            await BaseEntityRepository.DeleteAsync(entity);
        }
        catch (Exception ex)
        {
            return new ErrorResult(ex.Message);
        }

        return new SuccessResult($"'{id}' id'li {typeof(Event).Name} entitysi silindi.");
    }
}