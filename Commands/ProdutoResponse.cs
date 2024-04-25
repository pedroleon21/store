using Store.Models;

namespace Store.Commands
{
    public class ProdutoResponse
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public float preco { get; set; } = .0f;
        public int LojaId { get; set; }
        public DateTime DtCriacao { get; set; }
        public ProdutoResponse(Produto produto)
        {
            this.Id = produto.Id;
            this.Descricao = produto.Descricao;
            this.Nome = produto.Nome;
            this.LojaId = produto.LojaId;
            this.DtCriacao = produto.DtCriacao;
        }
    }
}
