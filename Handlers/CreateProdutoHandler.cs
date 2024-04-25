using Azure.Core;
using Store.Commands;
using Store.Data;
using Store.Models;

namespace Store.Handlers
{
    public class CreateProdutoHandler : ICreateProdutoHandler
    {
        private DataContext dataContext;
        public CreateProdutoHandler(DataContext dataContext) 
        {
            this.dataContext=dataContext;
        }
        public ProdutoResponse Handler(ProdutoCreateAction action)
        {
            var loja = dataContext.Lojas.Where(l => l.Id == action.LojaId).FirstOrDefault();
            if (loja == null)
            {
                throw new InvalidOperationException($"Usuario: {action.LojaId} não encontrado");
            }
            var produto = new Produto
            {
                LojaId = action.LojaId,
                Preco = action.Preco,
                Descricao = action.Descricao,
                Nome = action.Nome
            };
            dataContext.Produtos.Add(produto);
            dataContext.SaveChanges();
            return new ProdutoResponse(produto);
        }
    }
}
