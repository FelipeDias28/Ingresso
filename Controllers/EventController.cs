using Ingresso.Data.DTOs;
using Ingresso.Repository.InterfaceService;
using Ingresso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;
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

        [HttpPost("event")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateEventDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var newEvent = await _eventService.CreateEvent(model);

                return Created($"v1/todos/{newEvent}", newEvent);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionHandlerService.ExceptionMessage(ex.Message);

                if (!string.IsNullOrWhiteSpace(errorMessage))
                    return BadRequest(errorMessage);

                return StatusCode(500);
            }
        }

        [HttpGet("events")]
        [Authorize]
        public async Task<IActionResult> GetUsersAsync()
        {
            var allEvents = await _eventService.GetEvent();

            return Ok(allEvents);
        }

        [HttpGet("event/{id}")]
        [Authorize]
        public async Task<IActionResult> ListTypeEventByIdAsync([FromRoute] int id)
        {
            var currentEvent = await _eventService.GetEvent(id);

            if (!currentEvent.Any())
                return NotFound();

            return Ok(currentEvent);
        }


    }
}
