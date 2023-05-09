using Business.Abstract;
using Business.DTOs.City;
using Business.Utils;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;
[Authorize(Roles = UserRoles.Admin)]
public class CityController : CrudEntityController<CityGetDto,CityDto,CityDto>
{
    public CityController(ICityService service) : base(service)
    {
    }
}