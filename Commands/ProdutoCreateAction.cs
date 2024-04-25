namespace Store.Commands
{
    public class ProdutoCreateAction
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int LojaId { get; set; }
    }
}
