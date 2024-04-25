using Microsoft.EntityFrameworkCore;
using Store.Commands;
using Store.Data;

namespace Store.Handlers
{
    public class GetProdutoHandler : IGetProdutoHandler
    {
        private DataContext dataContext;
        public GetProdutoHandler(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        public ProdutoResponse Handler(int idProduto)
        {
            var produto = dataContext
                .Produtos
                .Where(p=>p.Id==idProduto)
                .FirstOrDefault();
            return new ProdutoResponse(produto!);
        }
    }
}
