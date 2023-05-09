using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Status;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;
[Authorize(Roles = UserRoles.Admin)]
public class StatusController : CrudEntityController<StatusGetDto,StatusDto,StatusDto>
{
    public StatusController(IStatusService service) : base(service)
    {
    }
}