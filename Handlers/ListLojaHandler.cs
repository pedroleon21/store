using Store.Commands;
using Store.Data;
using System.Linq;

namespace Store.Handlers
{
    public class ListLojaHandler : IListLojaHandler
    {
        private DataContext dataContext;
        public ListLojaHandler(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        public PageResult<LojaResponse> Handler(int? userId, int? PageIndex, int? PageSize)
        {
            return new PageResult<LojaResponse>
            {
                PageIndex = (PageIndex ?? 0),
                PageSize = (PageSize ??10),
                Count = dataContext.Lojas
                .Where(l => userId != null ? l.UsuarioId == userId : true)
                .Select(l => new LojaResponse(l))
                .Count(),
                Items = dataContext.Lojas
                .Where(l => userId != null ? l.UsuarioId == userId : true)
                .Select(l => new LojaResponse(l))
                .Skip((PageIndex ?? 0) * (PageSize ?? 10))
                .Take(PageSize ?? 10)
            };
        }
    }
}
