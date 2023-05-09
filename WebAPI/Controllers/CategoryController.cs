using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Category;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;

public class CategoryController : CrudEntityController<CategoryGetDto,CategoryDto,CategoryDto>
{
    public CategoryController(ICategoryService service) : base(service)
    {
    }
}