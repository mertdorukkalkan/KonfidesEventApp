using Domain;

namespace Core.Business.DTOs.Event;

public class EventGetDto : EventCreateDto,IEntityGetDto
{
    public int Id { get; set; }
    public string CityName { get; set; }
    public string  Street { get; set; }
    public string CategoryName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StatusCode { get; set; }
}