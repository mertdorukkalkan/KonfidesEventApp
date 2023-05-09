using Business.Abstract;
using Business.DTOs.City;
using Business.Utils;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;

public class CityController : CrudEntityController<CityGetDto,CityDto,CityDto>
{
    public CityController(ICityService service) : base(service)
    {
    }
}