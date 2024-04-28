namespace Store.Commands
{
    public class UpdateProdutoAction
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco {  get; set; }
        public string FotoBase64 { get; set; }
        public string Descricao { get; set;}
    }
}
