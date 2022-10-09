using Ingresso.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Ingresso.Data.DTOs;
using Ingresso.Repository.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Linq;

namespace Ingresso.Controllers
{
    [ApiController]
    [Route("v1")]
    public class StatusEventController : ControllerBase
    {
        private readonly IStatusEventService _statusEventService;

        public StatusEventController(IStatusEventService statusEventService)
        {
            _statusEventService = statusEventService;
        }

        [HttpPost("status-event")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateStatusEventAsync([FromBody] CreateStatusEventDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
               var newStatusEvent = await _statusEventService.CreateStatusEvent(model);

                return Created($"v1/event/{newStatusEvent.Id}", newStatusEvent);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("status-events")]
        [Authorize]
        public async Task<IActionResult> ListTypeUserAsync()
        {
            var statusEventList = await _statusEventService.GetStatusEvent();

            if (!statusEventList.Any())
                return BadRequest("Status do evento não encontrado");

            return Ok(statusEventList);
        }
    }
}
