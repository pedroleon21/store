using Microsoft.AspNetCore.Mvc;
using Store.Commands;
using Store.Handlers;

namespace Store.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public IActionResult login(
            [FromBody] AuthAction reques,
            [FromServices] IAuthHandler handler)
        {
            return Ok(handler.handler(reques));
        }
    }
}
