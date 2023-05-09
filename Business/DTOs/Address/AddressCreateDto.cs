using Core.Business.DTOs;

namespace Business.DTOs.Address;

public class AddressCreateDto : IDto
{
    public string Street { get; set; }
    public string AddressDescription { get; set; }
    public int CityId { get; set; }
}