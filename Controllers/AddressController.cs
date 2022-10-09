using Ingresso.Data.DTOs;
using Ingresso.Repository.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Ingresso.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("address")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateStatusEventAsync([FromBody] CreateAddressDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var newAddress = await _addressService.CreateAddress(model);

                return Created($"v1/event/{newAddress.Id}", newAddress);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("addresses")]
        [Authorize]
        public async Task<IActionResult> ListTypeUserAsync()
        {
            var addressList = await _addressService.GetAddresses();

            if (!addressList.Any())
                return BadRequest("Lista de Endereço não encontrado");

            return Ok(addressList);
        }
    }
}
