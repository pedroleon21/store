using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public PageResult<ProdutoResponse> Handler(int? lojaId, int? PageIndex, int? PageSize)
        {
            return new PageResult<ProdutoResponse>{
                PageIndex= (PageIndex ?? 0),
                PageSize =(PageSize ?? 10),
                Count = dataContext.Produtos
                .Where(p => lojaId != null ? p.LojaId == lojaId : true)
                .Select(p => new ProdutoResponse(p))
                .Count(),
                Items = dataContext.Produtos
                .Where(p => lojaId != null ? p.LojaId == lojaId : true)
                .Select(p=> new ProdutoResponse(p))
                .Skip((PageIndex ?? 0) * (PageSize ?? 10))
                .Take(PageSize ?? 10)
            };
                            
        }
    }
}
