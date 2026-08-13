using Customer.Application.DTOs;
using Customer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [Route("v1/[Controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IAppCustomerService _appService;
        public CustomerController(IAppCustomerService appService)
        {
            _appService = appService;
        }

        [HttpGet("Customer/{id}")]
        [ProducesResponseType(typeof(CustomerResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid id)
        {
            var result = await _appService.GetCustomerByIdAsync(id);
            return Ok(result);
            
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDTO request)
        {
            var result = _appService.RegisterCustomerAsync(request);
            return Ok(result);
        }
        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerDTO request)
        {
            var result = _appService.UpdateCustomerAsync(request);      
            return Ok(result);
        }
        [HttpDelete("Customer/{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCustomerById([FromRoute] Guid id)
        {
            var result = _appService.DeleteCustomerAsync(id);
            return Ok(result);
        }

    }
}
