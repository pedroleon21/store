using Store.Models;

namespace Store.Commands
{
    public class LojaResponse
    { 

        public LojaResponse(Loja result)
        {
            this.LojaId = result.Id;
            this.Nome = result.Nome;
            this.DtCriacao = result.DtCriacao;
            this.Usuario = new UserResponse(result.Usuario!);
        }
        public int? LojaId { get; set; }
        public string Nome { get; set; }
        public DateTime DtCriacao { get; set; }
        public UserResponse Usuario { get; set; }
    }
}