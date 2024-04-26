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
        public List<LojaResponse> Handler(int? userId)
        {
            return dataContext.Lojas
                .Where(l=>userId != null ? l.UsuarioId == userId : true)
                .Select(l => new LojaResponse(l))
                .ToList();
        }
    }
}
