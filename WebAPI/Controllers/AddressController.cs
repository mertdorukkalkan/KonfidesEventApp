using Business.Abstract;
using Business.DTOs.Address;
using Business.Utils;
using Core.Business.DTOs.Address;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;

public class AddressController : CrudEntityController<AddressGetDto,AddressCreateDto,AddressUpdateDto>
{
    public AddressController(IAddressService service) : base(service)
    {
    }
}