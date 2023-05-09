using Business.Abstract;
using Business.DTOs.Address;
using Business.Utils;
using Core.Business.DTOs.Address;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;
[Authorize]
public class AddressController : CrudEntityController<AddressGetDto,AddressCreateDto,AddressUpdateDto>
{
    public AddressController(IAddressService service) : base(service)
    {
    }
}