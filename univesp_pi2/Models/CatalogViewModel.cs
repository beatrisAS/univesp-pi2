using System.Collections.Generic;

public class CatalogViewModel
{
    public string? CurrentCategory { get; set; }
    public string? CurrentSearch { get; set; }
    public string? SortBy { get; set; }
    
    public bool InStockOnly { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; } = 500;
    

    public List<string> AvailableBrands { get; set; } = new List<string>();
    public List<Product> Products { get; set; } = new List<Product>();
    public List<string> SelectedBrands { get; set; } = new List<string>();
}