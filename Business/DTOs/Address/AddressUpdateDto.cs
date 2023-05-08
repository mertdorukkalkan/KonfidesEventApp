namespace Core.Business.DTOs.Address;

public class AddressUpdateDto : IDto
{
    public string Street { get; set; }
    public string Description { get; set; }
}