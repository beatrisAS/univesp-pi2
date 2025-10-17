using univesp_pi2.Models; 

public class ProductService
{
    private static readonly List<CategoryViewModel> _categories = new()
    {
        new() { Id = "freios", Name = "Freios", Icon = " disque" },
        new() { Id = "motor", Name = "Motor", Icon = " engrenagem" },
        new() { Id = "suspensao", Name = "Suspensão", Icon = " ferramenta" },
        new() { Id = "eletrica", Name = "Elétrica", Icon = " lâmpada" },
        new() { Id = "filtros", Name = "Filtros", Icon = " filtro" },
        new() { Id = "fluidos", Name = "Fluidos", Icon = " gota" }
    };

    private static readonly List<Product> _products = new()
    {
        new() {
            Id = 1, Name = "Bateria Automotiva 60Ah", Code = "MOU-BA-004", Brand = "Moura",
            Category = "eletrica", Price = 350.00m, Rating = 4.7, ReviewCount = 167, Stock = 10,
            ImageUrl = "images/Bateria Automotiva 60Ah.png", Descricao = "Bateria de alta performance para veículos de passeio."
        },
        new() {
            Id = 2, Name = "Pastilha de Freio Dianteira", Code = "BOS-PF-001", Brand = "Bosch",
            Category = "freios", Price = 120.00m, Rating = 4.5, ReviewCount = 128, Stock = 50,
            ImageUrl = "images/Pastilha de Freio Dianteira.png", Descricao = "Pastilhas de freio de cerâmica para maior durabilidade."
        },
        new() {
            Id = 3, Name = "Vela de Ignição Iridium", Code = "NGK-VI-006", Brand = "NGK",
            Category = "motor", Price = 55.00m, Rating = 4.9, ReviewCount = 312, Stock = 0,
            ImageUrl = "images/Vela de Ignição Iridium.png", Descricao = "Vela de ignição Iridium para melhor queima de combustível."
        }
    };

    public Task<List<Product>> GetProductsAsync() => Task.FromResult(_products);
    public Task<Product?> GetProductByIdAsync(int id) => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    public Task<List<CategoryViewModel>> GetCategoriesAsync() => Task.FromResult(_categories); 
    public Task<List<string>> GetBrandsAsync() => Task.FromResult(_products.Select(p => p.Brand).Distinct().ToList());
}