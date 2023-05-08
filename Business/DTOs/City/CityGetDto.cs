using Core.Business.DTOs;
using Core.Business.DTOs.Status;

namespace Business.DTOs.City;

public class CityGetDto : CityDto,IEntityGetDto
{
    public int Id { get; set; }
}