using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.Commands;
using Store.Handlers;

namespace Store.Controllers
{
    [ApiController]
    [Route("/loja")]
    public class LojaController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [ProducesResponseType(200, Type = typeof(LojaResponse))]
        public ActionResult create(
            [FromBody] CreateLojaAction request,
            [FromServices] ICreateLojaHandler handler
            ) 
        {
            return Ok(handler.Handler(request));
        }
        [HttpGet]
        [Route("{idLoja}")]
        [ProducesResponseType(200, Type = typeof(LojaResponse))]
        public ActionResult read(
            [FromRoute] int idLoja,
            [FromServices] IGetLoiaHandler handler)
        {
            return Ok(handler.Handler(idLoja));
        }
    }
}
