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
        }
        public int? LojaId { get; set; }
        public string Nome { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}