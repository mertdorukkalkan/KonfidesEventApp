using Business.Abstract;
using DataAccess.Domain;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Authorize(Roles = UserRoles.Admin)]
public class RoleController : ControllerBase
{
    private IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost]
    [Route("CreateRole")]
    public async Task<IActionResult> CreateRole(string roleName,string? description)
    {
        var result = await _roleService.CreateRole(roleName,description);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [HttpDelete]
    [Route("DeleteRole")]
    public async Task<IActionResult> DeleteRole(string role)
    {
        var result = await _roleService.DeleteRole(role);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

}