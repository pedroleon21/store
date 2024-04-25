using Store.Commands;

namespace Store.Handlers
{
    public interface ICreateProdutoHandler
    {
        public ProdutoResponse Handler(ProdutoCreateAction action);
    }
}
