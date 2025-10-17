using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Models;
using System.Collections.Generic;
using System.Linq;

namespace univesp_pi2.Controllers
{
    public class CatalogoController : Controller
    {
        public IActionResult Index(CatalogViewModel model)
        {
            var allProducts = GetProductsMock();
            model.AvailableBrands = allProducts.Select(p => p.Brand).Distinct().OrderBy(b => b).ToList();

            var filteredProducts = allProducts.AsEnumerable();

           
            if (!string.IsNullOrEmpty(model.CurrentCategory) && model.CurrentCategory != "Todos")
            {
                filteredProducts = filteredProducts.Where(p => 
                    p.Category.Equals(model.CurrentCategory, System.StringComparison.OrdinalIgnoreCase));
            }
            
      
            if (!string.IsNullOrEmpty(model.CurrentSearch))
            {
                string search = model.CurrentSearch.ToLower();
                filteredProducts = filteredProducts.Where(p => 
                    p.Name.ToLower().Contains(search) ||
                    p.Code.ToLower().Contains(search) ||
                    p.Brand.ToLower().Contains(search));
            }

           
            if (model.SelectedBrands != null && model.SelectedBrands.Any())
            {
                filteredProducts = filteredProducts.Where(p => model.SelectedBrands.Contains(p.Brand));
            }
            
      
            if (model.InStockOnly)
            {
                filteredProducts = filteredProducts.Where(p => p.IsInStock);
            }

          
            filteredProducts = filteredProducts.Where(p => p.FinalPrice >= model.MinPrice && p.FinalPrice <= model.MaxPrice);

         
            filteredProducts = model.SortBy switch
            {
                "PriceLow" => filteredProducts.OrderBy(p => p.FinalPrice),
                "PriceHigh" => filteredProducts.OrderByDescending(p => p.FinalPrice),
                "Name" or _ => filteredProducts.OrderBy(p => p.Name),
            };
           
            model.Products = filteredProducts.ToList();
            return View(model);
        }

        private List<Product> GetProductsMock()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Bateria Automotiva 60Ah", Code = "MOU-BA-004", Brand = "Moura", Category = "Elétrica", Price = 350.00m, DiscountPrice = 289.90m, Stock = 15, ImageUrl = "/images/Bateria Automotiva 60Ah.png", Rating = 4.7, ReviewCount = 167 },
                new Product { Id = 2, Name = "Pastilha de Freio Dianteira", Code = "BOS-PF-001", Brand = "Bosch", Category = "Freios", Price = 120.00m, DiscountPrice = 89.90m, Stock = 50, ImageUrl = "/images/Pastilha de Freio Dianteira.png", Rating = 4.5, ReviewCount = 128 },
                new Product { Id = 3, Name = "Vela de Ignição Iridium", Code = "NGK-VI-006", Brand = "NGK", Category = "Motor", Price = 55.00m, DiscountPrice = 45.90m, Stock = 0, ImageUrl = "/images/Vela de Ignição Iridium.png", Rating = 4.9, ReviewCount = 312 },
                new Product { Id = 4, Name = "Disco de Freio Ventilado", Code = "TRW-DF-005", Brand = "TRW", Category = "Freios", Price = 180.00m, DiscountPrice = 156.90m, Stock = 10, ImageUrl = "/images/Disco de Freio Ventilado.png", Rating = 4.4, ReviewCount = 92 },
                new Product { Id = 5, Name = "Filtro de Óleo do Motor", Code = "MAN-FO-002", Brand = "Mann-Filter", Category = "Fluidos", Price = 32.00m, DiscountPrice = 24.90m, Stock = 200, ImageUrl = "/images/Filtro de Óleo do Motor.png", Rating = 4.8, ReviewCount = 254 },
                new Product { Id = 6, Name = "Amortecedor Traseiro", Code = "MON-AT-003", Brand = "Monroe", Category = "Suspensão", Price = 250.00m, DiscountPrice = 189.90m, Stock = 5, ImageUrl = "/images/Amortecedor Traseiro.png", Rating = 4.6, ReviewCount = 89 },
                new Product { Id = 7, Name = "Óleo Motor 5W30 Sintético", Code = "CAS-OM-008", Brand = "Castrol", Category = "Fluidos", Price = 60.00m, DiscountPrice = 45.90m, Stock = 150, ImageUrl = "/images/Óleo Motor 5W30 Sintético.png", Rating = 4.8, ReviewCount = 445 },
                new Product { Id = 8, Name = "Correia Dentada", Code = "GAT-CD-010", Brand = "Gates", Category = "Motor", Price = 150.00m, DiscountPrice = 129.90m, Stock = 30, ImageUrl = "/images/Correia Dentada.png", Rating = 4.5, ReviewCount = 178 }
            };
        }
    }
}