using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class Produto
    {
        [Key]
        public int? Id { get; set; } 
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; } = 0m;
        public DateTime DtCriacao { get; set;} = DateTime.Now;
        [ForeignKey("Id")]
        public int LojaId { get; set; }
        public Loja Loja { get; set; } 
    }
}
