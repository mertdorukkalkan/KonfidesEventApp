using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Category;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;
[Authorize(Roles = UserRoles.Admin)]
public class CategoryController : CrudEntityController<CategoryGetDto,CategoryDto,CategoryDto>
{
    public CategoryController(ICategoryService service) : base(service)
    {
    }
}