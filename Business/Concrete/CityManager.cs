using AutoMapper;
using Business.Abstract;
using Business.DTOs.City;
using Business.Utils;
using DataAccess;
using Domain;

namespace Business.Concrete;

public class CityManager : CrudEntityManager<City,CityGetDto,CityDto,CityDto>,ICityService
{
    public CityManager(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}