using Store.Commands;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        // deveria se colocada alguma lógica de criptografia da senha.
        public string Password { get; set; } = string.Empty;
        [Column(TypeName = "datetime")]
        public DateTime DtCriacao { get; set; } = DateTime.Now;
        public ICollection<Loja> Lojas { get; set; } = new List<Loja>();
    }
}
