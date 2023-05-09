using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Ticket;
using Core.Utils.Results;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;
[Authorize]
public class TicketController : CrudEntityController<TicketGetDto,TicketCreateDto,TicketCreateDto>
{
    private readonly ITicketService _ticketService;
    public TicketController(ITicketService service, ITicketService ticketService) : base(service)
    {
        _ticketService = ticketService;
    }
    [Authorize(Roles = UserRoles.Security)]
    [HttpGet]
    [Route("TicketCheck")]
    public  async Task<IActionResult> TicketCheck(string code)
    {
        var result = await _ticketService.TicketCheck(code);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [HttpGet]
    [Route("GetUserTickets")]
    public  async Task<IActionResult> GetUserTickets()
    {
        var result = await _ticketService.GetUserTickets();
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    
}