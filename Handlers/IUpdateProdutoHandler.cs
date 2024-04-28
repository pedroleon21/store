using Store.Commands;

namespace Store.Handlers
{
    public interface IUpdateProdutoHandler
    {
        public ProdutoResponse Handler(UpdateProdutoAction action);
    }
}