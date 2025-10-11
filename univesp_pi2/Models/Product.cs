using System.ComponentModel.DataAnnotations;

namespace univesp_pi2.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100)]
        public string Name { get; set; }
        
        public string Code { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal DiscountPrice { get; set; } 
        
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        
        
        public bool IsOnOffer => DiscountPrice > 0 && DiscountPrice < Price;
        public bool IsInStock => Stock > 0;
        
        public decimal FinalPrice => IsOnOffer ? DiscountPrice : Price;
    }
}
