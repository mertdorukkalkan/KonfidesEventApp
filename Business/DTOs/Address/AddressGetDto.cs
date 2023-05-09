namespace Core.Business.DTOs.Address;

public class AddressGetDto: AddressCreateDto,IEntityGetDto
{
    public int Id { get; set; }
    
    
}