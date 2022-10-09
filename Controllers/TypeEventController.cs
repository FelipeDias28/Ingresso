using Ingresso.Data.DTOs;
using Ingresso.Repository.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;

namespace Ingresso.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TypeEventController : ControllerBase
    {
        private readonly ITypeEventService _typeEventService;

        public TypeEventController(ITypeEventService typeEventService)
        {
            _typeEventService = typeEventService;
        }

        [HttpPost("type-event")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTypeEventAsync([FromBody] CreateTypeEventDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var typeEvent = await _typeEventService.CreateTypeEvent(model);

                return Created($"v1/type-event/{typeEvent.Id}", typeEvent);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("type-events")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListTypeEventAsync()
        {
            var allTypeEvents = await _typeEventService.GetTypeEvent();

            return Ok(allTypeEvents);
        }
    }
}
