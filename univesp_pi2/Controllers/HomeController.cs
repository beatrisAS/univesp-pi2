using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Models;

namespace univesp_pi2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var allProducts = GetProductsMock();
            var viewModel = new HomeViewModel
            {
                FeaturedProducts = allProducts.Take(6).ToList(),
                Categories = allProducts
                    .Select(p => p.Category)
                    .Distinct()
                    .Select(c => new CategoryViewModel {
                        Id = c,
                        Name = c,
                        Icon = GetCategoryIconName(c)
                    }).ToList()
            };
            return View(viewModel);
        }

        private string GetCategoryIconName(string categoryName)
        {
            return categoryName.ToLower() switch
            {
                "freios" => "disc-3", "motor" => "settings", "suspensão" => "wrench",
                "elétrica" => "zap", "filtros" => "search", "fluidos" => "droplets",
                _ => "package"
            };
        }

        private List<Product> GetProductsMock()
        {
            return new List<Product> {
                new Product { Id = 1, Name = "Bateria Automotiva 60Ah", Code = "MOU-BA-004", Brand = "Moura", Category = "Elétrica", Price = 350.00m, DiscountPrice = 289.90m, Stock = 15, ImageUrl = "/images/Bateria Automotiva 60Ah.png", Rating = 4.7, ReviewCount = 167 },
                new Product { Id = 2, Name = "Pastilha de Freio Dianteira", Code = "BOS-PF-001", Brand = "Bosch", Category = "Freios", Price = 120.00m, DiscountPrice = 89.90m, Stock = 50, ImageUrl = "/images/Pastilha de Freio Dianteira.png", Rating = 4.5, ReviewCount = 128 },
                new Product { Id = 3, Name = "Vela de Ignição Iridium", Code = "NGK-VI-006", Brand = "NGK", Category = "Motor", Price = 55.00m, DiscountPrice = 45.90m, Stock = 0, ImageUrl = "/images/Vela de Ignição Iridium.png", Rating = 4.9, ReviewCount = 312 },
                new Product { Id = 4, Name = "Disco de Freio Ventilado", Code = "TRW-DF-005", Brand = "TRW", Category = "Freios", Price = 180.00m, DiscountPrice = 156.90m, Stock = 10, ImageUrl = "/images/Disco de Freio Ventilado.png", Rating = 4.4, ReviewCount = 92 },
                new Product { Id = 5, Name = "Filtro de Óleo do Motor", Code = "MAN-FO-002", Brand = "Mann-Filter", Category = "Fluidos", Price = 32.00m, DiscountPrice = 24.90m, Stock = 200, ImageUrl = "/images/Filtro de Óleo do Motor.png", Rating = 4.8, ReviewCount = 254 },
                new Product { Id = 6, Name = "Amortecedor Traseiro", Code = "MON-AT-003", Brand = "Monroe", Category = "Suspensão", Price = 250.00m, DiscountPrice = 189.90m, Stock = 5, ImageUrl = "/images/Amortecedor Traseiro.png", Rating = 4.6, ReviewCount = 89 }
            };
        }
    }
}