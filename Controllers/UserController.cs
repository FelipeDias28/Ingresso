using Ingresso.Data.DTOs;
using Ingresso.Entity;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("user")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var newUser = await _userService.CreateUser(model);

                return Created($"v1/todos/{newUser.Id}", newUser);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionHandlerService.ExceptionMessage(ex.Message);

                if (!string.IsNullOrWhiteSpace(errorMessage))
                    return NotFound(new { message = errorMessage });

                return StatusCode(500);
            }
        }

        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var allUsers = await _userService.GetAllUsers();

            if (!allUsers.Any())
                return NotFound(new { message = "Não foi encontrado nenhum usuário " });

            return Ok(allUsers);
        }

        [HttpGet("user/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid id)
        {
            try
            {
                var user = await _userService.GetUsersById(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                var errorMessage = ExceptionHandlerService.ExceptionMessage(ex.Message);

                if (!string.IsNullOrWhiteSpace(errorMessage))
                    return NotFound(new { message = errorMessage });

                return StatusCode(500);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] LoginDto model)
        {
            try
            {
                var tokenModel = await _userService.Authenticate(model);

                return Ok(tokenModel);
            }
            catch
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }
        }

        [HttpGet("event-user/{id}")]
        [Authorize]
        public async Task<IActionResult> GetEventsUserParticipateAsync([FromRoute] Guid id)
        {
            var user = await _userService.GetEventsUserParticipate(id);

            if (!user.Any())
                return NotFound(new { message = "Não foi encontrado nenhum evento para este usuário" });

            return Ok(user);
        }

        [HttpPut("user-update/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid id, [FromBody] UpdateUserDto model)
        {
            try
            {
                var user = await _userService.UpdateUser(id, model);
                return Ok(user);
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
