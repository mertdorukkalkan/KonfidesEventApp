using AutoMapper;
using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Address;
using Core.DataAccess;
using Core.Utils.Results;
using DataAccess;
using Domain;

namespace Business.Concrete;

public class AddressManager : CrudEntityManager<Address,AddressGetDto,AddressCreateDto,AddressUpdateDto>, IAddressService
{
    private IEntityRepository<City> _cityRepository;
    public AddressManager(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _cityRepository = unitOfWork.GenerateRepository<City>();
    }

    public async override Task<IDataResult<AddressGetDto>> AddAsync(AddressCreateDto input)
    {
        
        var entity = Mapper.Map<AddressCreateDto, Address>(input);
        await UnitOfWork.BeginTransactionAsync();
        try
        {
            var city = await _cityRepository.GetAsync(x => x.Id == input.CityId);
            entity.City = city;
            await BaseEntityRepository.AddAsync(entity);
        }
        catch (Exception ex)
        {
            await UnitOfWork.RollbackTransactionAsync();
            return new ErrorDataResult<AddressGetDto>(ex.Message);
        }

        await UnitOfWork.CommitTransactionAsync();
        return await GetByIdAsync(entity.Id);
    }

    public override async Task<IDataResult<ICollection<AddressGetDto>>> GetAllAsync()
    {
        var address = await BaseEntityRepository.GetListWithIncludeAsync(null, x => x.City);
        var addressGet = Mapper.Map<List<Address>, List<AddressGetDto>>(address.ToList());
        return new SuccessDataResult<ICollection<AddressGetDto>>(addressGet);
    }

    public override async Task<IDataResult<AddressGetDto>> GetByIdAsync(int id)
    {
        var address = await BaseEntityRepository.GetWithIncludeAsync(x => x.Id == id, x => x.City);

        if (address == null)
        {
            return new ErrorDataResult<AddressGetDto>($"'{id}' id'li Teacher entitysi bulunamadı.");
        }
            
        var addressDto = Mapper.Map<Address, AddressGetDto>(address);
        return new SuccessDataResult<AddressGetDto>(addressDto);
    }
}