using Business.Utils;
using Core.Business.DTOs.Category;

namespace Business.Abstract;

public interface ICategoryService : ICrudEntityService<CategoryGetDto,CategoryDto,CategoryDto>
{
    
}