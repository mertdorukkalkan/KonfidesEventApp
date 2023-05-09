using AutoMapper;
using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Status;
using DataAccess;
using Domain;

namespace Business.Concrete;

public class StatusManager : CrudEntityManager<Status,StatusGetDto,StatusDto,StatusDto>, IStatusService
{
    public StatusManager(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}