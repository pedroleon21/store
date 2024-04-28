using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Handlers
{
    public class DeleteLojaHandler : IDeleteLojaHandler
    {
        private DataContext dataContext;
        public DeleteLojaHandler(DataContext dataContext)
        {
            this.dataContext = dataContext; 
        }

        public void Handler(int idLoja)
        {
            var loja = dataContext.Lojas.Where(l =>l.Id == idLoja).FirstOrDefault();
            if (loja == null)
            {
                throw new InvalidOperationException($"Loja com id: {idLoja} não encontrado.");
            }
            dataContext.Remove(loja);
            dataContext.SaveChanges();
        }
    }
}
