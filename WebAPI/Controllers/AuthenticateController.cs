using Business.Abstract;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

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
}