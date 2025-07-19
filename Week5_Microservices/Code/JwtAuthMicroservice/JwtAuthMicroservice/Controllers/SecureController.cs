using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("data")]
        [Authorize]  // Requires a valid JWT token
        public IActionResult GetSecureData()
        {
            return Ok("This is protected data. You are authorized!");
        }
    }
}
