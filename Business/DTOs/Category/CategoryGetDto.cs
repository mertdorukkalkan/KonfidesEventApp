namespace Core.Business.DTOs.Category;

public class CategoryGetDto : CategoryDto,IEntityGetDto 
{
    public int Id { get; set; }
}