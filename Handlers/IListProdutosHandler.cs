using Store.Commands;

namespace Store.Handlers
{
    public interface IListProdutosHandler
    {
        public List<ProdutoResponse> Handler(int? lojaId);
    }
}
