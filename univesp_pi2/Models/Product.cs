namespace univesp_pi2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Stock { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Detalhes { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public List<string> Compatibility { get; set; } = new();

        public bool IsOnOffer => DiscountPrice > 0;
        public bool IsInStock => Stock > 0;
        public decimal FinalPrice => IsOnOffer ? DiscountPrice : Price;
    }
}