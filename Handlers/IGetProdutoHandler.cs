using Store.Commands;

namespace Store.Handlers
{
    public interface IGetProdutoHandler
    {
        public ProdutoResponse Handler(int idProduto);
    }
}
