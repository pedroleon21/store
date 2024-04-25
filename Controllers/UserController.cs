using Microsoft.AspNetCore.Mvc;
using Store.Commands;
using Store.Handlers;

namespace Store.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("auth")]
        public IActionResult login(
            [FromBody] AuthAction reques,
            [FromServices] IAuthHancler handler)
        {
            handler.handler(reques);
            return Ok();
        }
        [HttpPost]
        [Route("")]
        [ProducesResponseType(200,Type = typeof(UserResponse))]
        public IActionResult create(
            [FromServices] ICreateUserHandler handler,
            [FromBody] CreateUserAction request
            )
        {
            var respose = handler.Handler( request );
            return Ok(respose);
        }
        [HttpGet]
        [Route("{userId}")]
        [ProducesResponseType(200, Type= typeof(UserResponse))]
        public IActionResult getById(
            [FromRoute] int userId,
            [FromServices] IGetUserHandler handler
            )
        {
            return Ok(handler.Handler(userId));
        }
    }
}
