using Microsoft.EntityFrameworkCore;
using Store.Commands;
using Store.Data;

namespace Store.Handlers
{
    public class GetLojaHandler : IGetLojaHandler
    {
        private DataContext dataContext;
        public GetLojaHandler(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        public LojaResponse Handler(int id)
        {
            var result = dataContext
                .Lojas
                .Where(l => l.Id == id)
                .Include(l=>l.Usuario)
                .FirstOrDefault();
            return new LojaResponse(result!);
        }
    }
}
