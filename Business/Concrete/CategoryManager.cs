using AutoMapper;
using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Category;
using DataAccess;
using Domain;

namespace Business.Concrete;

public class CategoryManager : CrudEntityManager<Category,CategoryGetDto,CategoryDto,CategoryDto>, ICategoryService
{
    public CategoryManager(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}