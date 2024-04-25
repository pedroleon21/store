using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class Loja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtCriacao { get; set; } = DateTime.Now;
        public ICollection<Produto> produtos { get; set; } = new List<Produto>();
        
        [ForeignKey("Id")]
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
