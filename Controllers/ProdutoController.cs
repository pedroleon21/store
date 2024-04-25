using Microsoft.AspNetCore.Mvc;
using Store.Commands;
using Store.Handlers;

namespace Store.Controllers
{
    [ApiController]
    [Route("/produto")]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [ProducesResponseType(200, Type = typeof(ProdutoResponse))]
        public IActionResult create(
            [FromBody] ProdutoCreateAction request,
            [FromServices] ICreateProdutoHandler handler
            )
        {
            return Ok(handler.Handler(request));
        }
        [HttpGet]
        [Route("{idProduto}")]
        [ProducesResponseType(200, Type = typeof(ProdutoResponse))]
        public IActionResult read(
            [FromRoute] int idProduto,
            [FromServices] IGetProdutoHandler handler)
        {
            return Ok(handler.Handler(idProduto));
        }
    }
}
