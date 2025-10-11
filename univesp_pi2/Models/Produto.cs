namespace univesp_pi2.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public decimal Preco { get; set; }
        public required string Descricao { get; set; }
        public required string Detalhes { get; set; }
        public required string ImagemUrl { get; set; }
    }
}
