using Ingresso.Data.DTOs;
using Ingresso.Entity;
using Ingresso.Repository.InterfaceService;
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
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var allUsers = await _userService.GetUsers(Guid.Empty);

            return Ok(allUsers);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid id)
        {
            var user = await _userService.GetUsers(id);

            if (!user.Any())
                return NotFound("usuário não encontrado");

            return Ok(user.First());
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
    }
}
