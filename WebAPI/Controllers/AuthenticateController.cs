using Business.Abstract;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthenticateService _authenticateService;

    public AuthenticateController(IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var result = await _authenticateService.Login(model);
        if (result.Success)
        {
           return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var result = await _authenticateService.Register(model);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
    {
        var result = await _authenticateService.RegisterAdmin(model);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [Authorize]
    [HttpPost]
    [Route("change-password")]
    public async Task<IActionResult> ChangePassword(string email, string password)
    {
        var result = await _authenticateService.ChangePassword(email,password);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost]
    [Route("add-role-to-user")]
    public async Task<IActionResult> AddRoleToUser(string email, string role)
    {
        var result = await _authenticateService.AddRoleToUser(email,role);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [Authorize(Roles = UserRoles.Admin)]
    [HttpGet]
    [Route("get-all-user")]
    public  IActionResult GetUserEvents()
    {
        var result =  _authenticateService.GetUsers();
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    
}