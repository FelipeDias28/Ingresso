using Ingresso.Data.DTOs;
using Ingresso.Repository.InterfaceService;
using Ingresso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> GetUsersAsync()
        {
            var allEvents = await _eventService.GetAllEvent();

            return Ok(allEvents);
        }

        [HttpGet("event/{id}")]
        public async Task<IActionResult> ListTypeEventByIdAsync([FromRoute] int id)
        {
            try
            {
                var currentEvent = await _eventService.GetEventById(id);

                return Ok(currentEvent);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionHandlerService.ExceptionMessage(ex.Message);

                if (!string.IsNullOrWhiteSpace(errorMessage))
                    return BadRequest(errorMessage);

                return StatusCode(500);
            }
        }

        [HttpGet("users-event/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsersParticipatingAsync([FromRoute] int id)
        {
            var participantsInEvent = await _eventService.GetUsersParticipatingEvent(id);

            if (!participantsInEvent.Any())
                return NotFound(new { message = " Não foi encontrado nenhum usuário para este evento" });

            return Ok(participantsInEvent);
        }

        [HttpPut("event-update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEventAsync([FromRoute] int id, [FromBody] UpdateEventDto model)
        {
            try
            {
                var modifiedEvent = await _eventService.UpdateEvent(id, model);
                return Ok(modifiedEvent);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionHandlerService.ExceptionMessage(ex.Message);

                if (!string.IsNullOrWhiteSpace(errorMessage))
                    return NotFound(new { message = errorMessage });

                return StatusCode(500);
            }
        }
    }
}
