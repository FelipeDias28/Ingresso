using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Ingresso.Data.DTOs;
using Ingresso.Repository.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Ingresso.Services;
using System.Linq;

namespace Ingresso.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("ticket")]
        [Authorize(Roles = "Buyer")]
        public async Task<IActionResult> CreateTicketAsync(BuyTicketDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var ticket = await _ticketService.BuyTicket(model);

                return Ok(new 
                { 
                    message = "Compra realizada com sucesso!", 
                    Id = ticket.Id,
                });
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionHandlerService.ExceptionMessage(ex.Message);

                if (!string.IsNullOrWhiteSpace(errorMessage))
                    return BadRequest(errorMessage);

                return StatusCode(500);
            }
        }

        [HttpGet("tickets")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTicketsAsync()
        {
            var tickets = await _ticketService.GetAllTickets();

            if (!tickets.Any())
                return BadRequest("Não foi encontrado nenhum ingresso");

            return Ok(tickets);
        }

        [HttpGet("ticket/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTicketsAsync([FromRoute] Guid id)
        {
            try
            {
                var ticket = await _ticketService.GetTicketById(id);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionHandlerService.ExceptionMessage(ex.Message);

                if (!string.IsNullOrWhiteSpace(errorMessage))
                    return BadRequest(errorMessage);

                return StatusCode(500);
            }
        }
    }
}
