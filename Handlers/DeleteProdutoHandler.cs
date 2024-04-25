using Microsoft.EntityFrameworkCore;
using Store.Data;

namespace Store.Handlers
{
    public class DeleteProdutoHandler : IDeleteProdutoHandler
    {
        private DataContext dataContext;
        public DeleteProdutoHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Handler(int idProduto)
        {
            var produto = dataContext.Produtos.Where(p=>p.Id==idProduto).FirstOrDefault();
            if (produto == null)
            {
                throw new InvalidOperationException($"Produto com id: {idProduto} não encontrado.");
            }
            dataContext.Remove(produto);
            dataContext.SaveChanges();
        }
    }
}
