using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity_SecureApiTemplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureDataController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("Access granted to admin resource.");
        }

        [Authorize]
        [HttpGet("user")]
        public IActionResult UserEndpoint()
        {
            return Ok("Access granted to authenticated users.");
        }
    }
}
