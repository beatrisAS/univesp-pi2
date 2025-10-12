namespace univesp_pi2.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; } = new();
        public List<Product> RelatedProducts { get; set; } = new();
        public List<ReviewViewModel> Reviews { get; set; } = new();
    }
}