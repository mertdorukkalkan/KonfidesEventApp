namespace Core.Business.DTOs.Status;

public class StatusGetDto : StatusDto,IEntityGetDto
{
    public int Id { get; set; }
}