namespace univesp_pi2.Models
{
    public class HomeViewModel
    {
        public List<Product> FeaturedProducts { get; set; } = new();
        public List<CategoryViewModel> Categories { get; set; } = new();
    }
}