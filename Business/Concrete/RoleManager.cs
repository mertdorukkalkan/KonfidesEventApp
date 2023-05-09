using Business.Abstract;
using Core.Domain;
using Core.Utils.Results;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete;

public class RoleManager : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager;

    public RoleManager(RoleManager<ApplicationRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<IResult> CreateRole(string roleName,string? description)
    {
        IdentityResult result = null;
        result = await _roleManager.CreateAsync(new ApplicationRole(){Name = roleName,Description = description});
        if (await _roleManager.RoleExistsAsync(roleName))
        {
            return new ErrorResult("Role already exists");
        }
        if (result.Succeeded)
        {
            return new SuccessResult("Rol Yaratıldı");
        }

        return new ErrorResult();
    }

    public async Task<IResult> DeleteRole(string role)
    {
        IdentityResult result = null;
        var entity = await _roleManager.FindByNameAsync(role); 
        result = await _roleManager.DeleteAsync(entity);
        if (result.Succeeded)
        {
            return new SuccessResult("Rol Yaratıldı");
        }

        return new ErrorResult();
    }
    
}