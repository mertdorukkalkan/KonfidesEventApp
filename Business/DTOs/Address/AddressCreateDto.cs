namespace Core.Business.DTOs.Address;

public class AddressCreateDto : IDto
{
    public string Street { get; set; }
    public string Description { get; set; }
    //City's Name
    public string Name { get; set; }
}