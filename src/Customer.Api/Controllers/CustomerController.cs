using Customer.Api.Controllers.Base;
using Customer.Application.DTOs;
using Customer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [Route("v1/[Controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly IAppCustomerService _appService;
        public CustomerController(IAppCustomerService appService)
        {
            _appService = appService;
        }

        [HttpGet("Customer/{id}")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid id)
        {
            var result = await _appService.GetCustomerByIdAsync(id);
            return await HandleReturn(result);

        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _appService.GetCustomersAsync();
            return await HandleReturn(result);

        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDTO request)
        {
            var result = await _appService.RegisterCustomerAsync(request);
            return await HandleReturn(result);
        }


        [HttpPut]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerDTO request)
        {
            var result = await _appService.UpdateCustomerAsync(request);
            return await HandleReturn(result);
        }
        [HttpDelete("Customer/{id}")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCustomerById([FromRoute] Guid id)
        {
            var result = await _appService.DeleteCustomerAsync(id);
            return await HandleReturn(result);
        }

    }
}
