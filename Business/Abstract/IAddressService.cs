using Business.Utils;
using Core.Business.DTOs.Address;

namespace Business.Abstract;

public interface IAddressService : ICrudEntityService<AddressGetDto,AddressCreateDto,AddressUpdateDto>
{
    
}