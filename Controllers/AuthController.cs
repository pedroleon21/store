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
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400, Type = typeof(void))]
        public IActionResult login(
            [FromBody] AuthAction reques,
            [FromServices] IAuthHandler handler)
        {
            try{ 
                return Ok(handler.handler(reques));
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    mensagem= ex.Message,
                });
            }
        }
    }
}
