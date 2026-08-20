using Customer.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected async Task<IActionResult> HandleReturn(BaseResponse response)
        {
            if (response.Data != null || response.Success)
                return Ok(response);
            else if (response.Data == null && response.Notifications == null)
                return NoContent();
            else
                return BadRequest(response);
        }
    }
}
