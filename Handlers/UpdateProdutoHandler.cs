using Store.Commands;
using Store.Data;

namespace Store.Handlers
{
    public class UpdateProdutoHandler : IUpdateProdutoHandler
    {
        private DataContext dataContext;
        public UpdateProdutoHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public ProdutoResponse Handler(UpdateProdutoAction action)
        {
            var produto = dataContext.Produtos.Where(p=>p.Id==action.Id).FirstOrDefault();
            if(produto == null)
            {
                throw new InvalidOperationException("Loja não encontrada");
            }
            produto.Nome = action.Nome;
            produto.Preco= action.Preco;
            produto.FotoBase64 = action.FotoBase64;
            produto.Descricao = action.Descricao;
            dataContext.Produtos.Update(produto);
            dataContext.SaveChanges();
            return new ProdutoResponse(produto);
        }
    }
}
