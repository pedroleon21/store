using Microsoft.AspNetCore.Mvc;
using Store.Commands;
using Store.Handlers;

namespace Store.Controllers
{
    [ApiController]
    [Route("/produto")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [ProducesResponseType(200, Type = typeof(PageResult<ProdutoResponse>))]
        public IActionResult index(
            [FromQuery] int? lojaId,
            [FromQuery] int? PageIndex,
            [FromQuery] int? PageSize,
            [FromServices] IListProdutosHandler handler) 
        {
            return Ok(handler.Handler(lojaId,PageIndex,PageSize));
        }
        [HttpDelete]
        [Route("{idProduto}")]
        [ProducesResponseType(200, Type = typeof(void))]
        public IActionResult delete(
          [FromRoute] int idProduto,
          [FromServices] IDeleteProdutoHandler handler)
        {
            handler.Handler(idProduto);
            return Ok();
        }
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
        [HttpPut]
        [Route("")]
        [ProducesResponseType(200, Type = typeof(ProdutoResponse))]
        public IActionResult update(
            [FromBody] UpdateProdutoAction request,
            [FromServices] IUpdateProdutoHandler handler)
        {
            return Ok(handler.Handler(request));
        }
    }
}
