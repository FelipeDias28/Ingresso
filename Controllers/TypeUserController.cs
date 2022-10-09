using Ingresso.Data.Dto;
using Ingresso.Repository.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Ingresso.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TypeUserController : ControllerBase
    {
        private readonly ITypeUserService _typeUserService;

        public TypeUserController(ITypeUserService typeUserService)
        {
            _typeUserService = typeUserService;
        }

        [HttpPost("type-user")]
        public async Task<IActionResult> CreateTypeUserAsync([FromBody] CreateTypeUserDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var typeUser = await _typeUserService.CreateTypeUser(model);
                return Created($"v1/event/{typeUser.Id}", typeUser); ;
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("type-users")]
        public async Task<IActionResult> GetAllTypeUserAsync()
        {
            var typeUsers = await _typeUserService.GetTypeUser();

            if (!typeUsers.Any())
                return BadRequest("Não foi possível encontrar nenhum tipo de usuário");

            return Ok(typeUsers);
        }


    }
}
