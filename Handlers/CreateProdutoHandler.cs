using Azure.Core;
using Store.Commands;
using Store.Data;
using Store.Models;

namespace Store.Handlers
{
    public class CreateProdutoHandler : ICreateProdutoHandler
    {
        private DataContext dataContext;
        private ICatalogEventHandler catalogHandler;
        public CreateProdutoHandler(DataContext dataContext, ICatalogEventHandler catalogHandler) 
        {
            this.dataContext=dataContext;
            this.catalogHandler = catalogHandler;
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
                FotoBase64 = action.FotoBase64,
                Nome = action.Nome
            };
            dataContext.Produtos.Add(produto);
            var emails = dataContext.Users.Select(u=> u.Email);
            dataContext.SaveChanges();
            catalogHandler.Handler(produto,emails);
            return new ProdutoResponse(produto);
        }
    }
}
