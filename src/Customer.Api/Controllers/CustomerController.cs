using Customer.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [Route("v1/[Controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("Customer/{id}")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid id)
        {
            return Ok(new CustomerResponse
            {
                Id = Guid.NewGuid(),
                Cpf = "39924134896",
                Name = "João",
                Sobrenome = "Lavor",
                BirthDate = DateTime.Now
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerRequest request)
        {
            return Ok("OK");
        }
        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest request)
        {
            return Ok("OK");
        }
        [HttpDelete("Customer/{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCustomerById([FromRoute] Guid id)
        {
            return Ok("OK");
        }

    }
}
