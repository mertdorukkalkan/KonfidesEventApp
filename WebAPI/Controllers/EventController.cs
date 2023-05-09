using Business.Abstract;
using Business.Utils;
using Core.Business.DTOs.Event;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers;

public class EventController :CrudEntityController<EventGetDto,EventCreateDto,EventUpdateDto>
{
    public EventController(IEventService service) : base(service)
    {
    }
    
}