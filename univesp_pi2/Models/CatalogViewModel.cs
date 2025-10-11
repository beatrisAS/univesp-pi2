using System.Collections.Generic;
using univesp_pi2.Models; 

namespace univesp_pi2.Models
{
    public class CatalogViewModel
    {
     
        public List<Product> Products { get; set; }

      
        public List<string> AvailableBrands { get; set; }
       public List<string> AvailableCategories { get; set; }

        
        public string CurrentSearch { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentBrand { get; set; }
        
        
        public decimal MinPrice { get; set; } = 0.00m; 
        public decimal MaxPrice { get; set; } = 500.00m; 
        public bool InStockOnly { get; set; }
        
     
        public string SortBy { get; set; } = "NameA-Z"; 
        public string ViewMode { get; set; } = "grid";

        public CatalogViewModel()
        {
            Products = new List<Product>();
            AvailableBrands = new List<string>();
        }
    }
}
