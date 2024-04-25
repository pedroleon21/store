using Store.Commands;
using Store.Data;

namespace Store.Handlers
{
    public class ListProdutosHandler : IListProdutosHandler
    {
        private DataContext dataContext;
        public ListProdutosHandler(DataContext dataContext)
        { 
            this.dataContext = dataContext;
        }
        public List<ProdutoResponse> Handler(int? lojaId)
        {
            return dataContext.Produtos
                .Where(p => lojaId != null ? p.LojaId == lojaId : true)
                .Select(p=> new ProdutoResponse(p))
                .ToList();
                            
        }
    }
}
