using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Status;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;

public class StatusController : CrudEntityController<StatusGetDto,StatusDto,StatusDto>
{
    public StatusController(IStatusService service) : base(service)
    {
    }
}