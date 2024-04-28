using Store.Commands;

namespace Store.Handlers
{
    public interface IListProdutosHandler
    {
        public PageResult<ProdutoResponse> Handler(int? lojaId, int? PageIndex, int? PageSize);
    }
}
