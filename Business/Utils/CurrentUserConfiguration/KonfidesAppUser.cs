using System.Security.Claims;
using Core.Domain;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Business.Utils.CurrentUserConfiguration;

public class KonfidesAppUser 
{
    private UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _accessor;

    public ClaimsPrincipal? Claims { get; set; }
    public ApplicationUser? User { get; set; }
    
    public KonfidesAppUser(UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
    {
        _userManager = userManager;
        _accessor = accessor;
        SetUser();
        
    }
    public async void SetUser() {
        Claims = _accessor?.HttpContext?.User;
        if (Claims.Identity.Name!=null)
        {
            User = await _userManager.FindByNameAsync(Claims.Identity.Name); 
        }
        
    }
    
}