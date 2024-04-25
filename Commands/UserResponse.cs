using Microsoft.AspNetCore.Routing.Constraints;
using Store.Models;

namespace Store.Commands
{
    public class UserResponse
    {
        public UserResponse(Usuario user) {
            this.Id = user.Id;
            this.Nome = user.Nome;
            this.Email = user.Email;
            this.Username = user.Username;
            this.DtCriacao = user.DtCriacao;
        }
        public UserResponse(int Id, string Nome, string Email,string Username, DateTime DtCriacao) 
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Email = Email;
            this.Username = Username;
            this.DtCriacao = DtCriacao;
        }
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; } 
        public string Username { get; set; } 
        public DateTime DtCriacao { get; private set; }
    }
}
