using Ingresso.Data.DTOs;
using Ingresso.Repository.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ingresso.Controllers
{
    [ApiController]
    [Route("v1")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        //[HttpPost("event")]
        //public async Task<IActionResult> CreateUserAsync([FromBody] CreateEventDto model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    try
        //    {
        //        var newEvent = await _eventService.CreateEvent(model);

        //        return Created($"v1/todos/{newEvent.Id}", newEvent);
        //    }
        //    catch
        //    {
        //        return StatusCode(500);
        //    }
        //}
    }
}
