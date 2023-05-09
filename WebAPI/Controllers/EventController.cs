using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;
[Authorize]
public class EventController :CrudEntityController<EventGetDto,EventCreateDto,EventUpdateDto>
{
    private IEventService _service;
    public EventController(IEventService service) : base(service)
    {
        _service = service;
    }
    [HttpGet]
    [Route("GetUserEvents")]
    public  async Task<IActionResult> GetUserEvents()
    {
        var result = await _service.GetUserEvents();
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}