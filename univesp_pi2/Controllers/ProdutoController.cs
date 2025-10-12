using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Models;

namespace univesp_pi2.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Detalhes(int id)
        {
            var allProducts = GetProductsMock();
            var produto = allProducts.FirstOrDefault(p => p.Id == id);

            if (produto == null) { return NotFound(); }
            
            var relatedProducts = allProducts.Where(p => p.Category == produto.Category && p.Id != produto.Id).Take(4).ToList();
            var reviews = new List<ReviewViewModel> {
                new ReviewViewModel { Id = 1, Author = "João Silva", Rating = 5, Date = "2024-01-15", Comment = "Produto de excelente qualidade, instalação fácil e funcionamento perfeito." },
                new ReviewViewModel { Id = 2, Author = "Maria Santos", Rating = 4, Date = "2024-01-10", Comment = "Boa peça, chegou rapidamente. Recomendo." },
                new ReviewViewModel { Id = 3, Author = "Carlos Oliveira", Rating = 5, Date = "2024-01-05", Comment = "Superou minhas expectativas. Produto original e bem embalado." }
            };

            var viewModel = new ProductDetailViewModel {
                Product = produto,
                RelatedProducts = relatedProducts,
                Reviews = reviews
            };

            return View(viewModel);
        }

        private List<Product> GetProductsMock()
        {
            return new List<Product> {
                new Product { 
                    Id = 1, Name = "Bateria Automotiva 60Ah", Code = "MOU-BA-004", Brand = "Moura", Category = "Elétrica", 
                    Price = 350.00m, DiscountPrice = 289.90m, Stock = 15, ImageUrl = "/images/Bateria Automotiva 60Ah.png", 
                    Rating = 4.7, ReviewCount = 167, 
                    Descricao = "Bateria de alta performance para veículos de passeio, com maior vida útil e resistência a vibrações.", 
                    Compatibility = new List<string> { "VW Gol G5/G6", "Fiat Palio 1.4", "Ford Ka 2015+" } 
                },
                new Product { 
                    Id = 2, Name = "Pastilha de Freio Dianteira", Code = "BOS-PF-001", Brand = "Bosch", Category = "Freios", 
                    Price = 120.00m, DiscountPrice = 89.90m, Stock = 50, ImageUrl = "/images/Pastilha de Freio Dianteira.png", 
                    Rating = 4.5, ReviewCount = 128, 
                    Descricao = "Pastilhas de freio de cerâmica para maior durabilidade, menos ruído e performance de frenagem superior.", 
                    Compatibility = new List<string> { "Chevrolet Onix", "Hyundai HB20", "Renault Sandero" } 
                },
                new Product { 
                    Id = 3, Name = "Vela de Ignição Iridium", Code = "NGK-VI-006", Brand = "NGK", Category = "Motor", 
                    Price = 55.00m, DiscountPrice = 45.90m, Stock = 0, ImageUrl = "/images/Vela de Ignição Iridium.png", 
                    Rating = 4.9, ReviewCount = 312, 
                    Descricao = "Vela de ignição com ponta de Iridium para melhor queima de combustível, partida mais rápida e maior vida útil do motor.", 
                    Compatibility = new List<string> { "Honda Civic 1.8", "Toyota Corolla 2.0", "Nissan Sentra" } 
                },
                new Product { 
                    Id = 4, Name = "Disco de Freio Ventilado", Code = "TRW-DF-005", Brand = "TRW", Category = "Freios", 
                    Price = 180.00m, DiscountPrice = 156.90m, Stock = 10, ImageUrl = "/images/Disco de Freio Ventilado.png", 
                    Rating = 4.4, ReviewCount = 92, 
                    Descricao = "Disco de freio ventilado projetado para melhor dissipação de calor, prevenindo o superaquecimento e garantindo frenagens seguras.", 
                    Compatibility = new List<string> { "VW Jetta", "Ford Focus" } 
                },
                new Product { 
                    Id = 5, Name = "Filtro de Óleo do Motor", Code = "MAN-FO-002", Brand = "Mann-Filter", Category = "Fluidos", 
                    Price = 32.00m, DiscountPrice = 24.90m, Stock = 200, ImageUrl = "/images/Filtro de Óleo do Motor.png", 
                    Rating = 4.8, ReviewCount = 254, 
                    Descricao = "Filtro de óleo de alta eficiência que remove impurezas e contaminantes, protegendo o motor e garantindo a lubrificação ideal.", 
                    Compatibility = new List<string> { "VW Fox", "Fiat Uno", "Ford Fiesta" } 
                },
                new Product { 
                    Id = 6, Name = "Amortecedor Traseiro", Code = "MON-AT-003", Brand = "Monroe", Category = "Suspensão", 
                    Price = 250.00m, DiscountPrice = 189.90m, Stock = 5, ImageUrl = "/images/Amortecedor Traseiro.png", 
                    Rating = 4.6, ReviewCount = 89, 
                    Descricao = "Amortecedor traseiro de qualidade original que proporciona maior conforto, estabilidade e segurança ao dirigir.", 
                    Compatibility = new List<string> { "Chevrolet Corsa", "VW Voyage" } 
                },
                new Product { 
                    Id = 7, Name = "Óleo Motor 5W30 Sintético", Code = "CAS-OM-008", Brand = "Castrol", Category = "Fluidos", 
                    Price = 60.00m, DiscountPrice = 45.90m, Stock = 150, ImageUrl = "/images/Óleo Motor 5W30 Sintético.png", 
                    Rating = 4.8, ReviewCount = 445, 
                    Descricao = "Óleo de motor 100% sintético 5W30, formulado para máxima proteção contra o desgaste e desempenho em altas temperaturas.", 
                    Compatibility = new List<string> { "Universal para motores modernos" } 
                },
                new Product { 
                    Id = 8, Name = "Correia Dentada", Code = "GAT-CD-010", Brand = "Gates", Category = "Motor", 
                    Price = 150.00m, DiscountPrice = 129.90m, Stock = 30, ImageUrl = "/images/Correia Dentada.png", 
                    Rating = 4.5, ReviewCount = 178, 
                    Descricao = "Correia dentada de alta durabilidade, essencial para o sincronismo do motor, evitando danos graves e garantindo o funcionamento correto.", 
                    Compatibility = new List<string> { "Fiat Strada", "VW Saveiro" } 
                }
            };
        }
    }
}