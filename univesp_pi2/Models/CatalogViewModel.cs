namespace univesp_pi2.Models
{
    public class CatalogViewModel
    {
        
        public List<Product> Products { get; set; } = new List<Product>();
        public List<string> AvailableBrands { get; set; } = new List<string>();
        
   
        public string CurrentSearch { get; set; } = string.Empty;
        public string CurrentCategory { get; set; } = string.Empty;
        public string CurrentBrand { get; set; } = string.Empty;
        public string SortBy { get; set; } = string.Empty;
        
        public bool InStockOnly { get; set; }
        public decimal MinPrice { get; set; } = 0.00m;
        public decimal MaxPrice { get; set; } = 10000.00m;
    }
}