using Business.Utils;
using Core.Business.DTOs.Status;

namespace Business.Abstract;

public interface IStatusService : ICrudEntityService<StatusGetDto,StatusDto,StatusDto>
{
    
}