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
        [HttpGet]
        [Route("")]
        [ProducesResponseType(200, Type = typeof(PageResult<LojaResponse>))]
        public IActionResult list(
            [FromQuery] int? userId,
            [FromQuery] int? PageIndex,
            [FromQuery] int? PageSize,
            [FromServices] IListLojaHandler handler)
        {
            return Ok(handler.Handler(userId,PageIndex, PageSize));
        }

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
            [FromServices] IGetLojaHandler handler)
        {
            return Ok(handler.Handler(idLoja));
        }
        [HttpDelete]
        [Route("{idLoja}")]
        [ProducesResponseType(200, Type = typeof(void))]
        public IActionResult delete(
            [FromRoute] int idLoja,
            [FromServices] IDeleteLojaHandler handler )
        {
            handler.Handler(idLoja);
            return Ok();
        }
    }
}
