using Microsoft.AspNetCore.Mvc;
using Store.Commands;
using Store.Data;
using Store.Models;

namespace Store.Handlers
{
    public class CreateLojaHandler : ICreateLojaHandler
    {
        private DataContext dataContext;
        public CreateLojaHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public LojaResponse Handler(CreateLojaAction request)
        {
            var user = dataContext.Users.Where(u=>u.Id== request.UserId).FirstOrDefault();
            if (user == null) 
            {
                throw new InvalidOperationException($"Usuario: {request.UserId} não encontrado");
            }
            var loja = new Loja
            {
                UsuarioId = request.UserId,
                Nome = request.nome
            };
            dataContext.Lojas.Add(loja);
            dataContext.SaveChanges();
            return new LojaResponse(loja);
        }
    }
}
