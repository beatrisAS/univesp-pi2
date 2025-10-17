using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Areas.Admin.Models;
using univesp_pi2.Models;

namespace univesp_pi2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                VendasTotais = 45689.90m,
                TotalPedidos = 156,
                TotalClientes = 1248,
                ProdutosBaixoEstoque = 8,
                ProdutosMaisVendidos = new List<Product>
                {
                    new Product { Name = "Pastilha de Freio Dianteira", Brand = "Bosch", Price = 89.90m, ImageUrl = "/images/Pastilha de Freio Dianteira.png" },
                    new Product { Name = "Filtro de Óleo do Motor", Brand = "Mann-Filter", Price = 24.90m, ImageUrl = "/images/Filtro de Óleo do Motor.png" }
                },
                PedidosRecentes = new List<PedidoViewModel>
                {
                    new PedidoViewModel { Id = 1, ClienteNome = "João Silva", Data = DateTime.Parse("2024-01-15"), Status = "Enviado", Total = 189.90m },
                    new PedidoViewModel { Id = 2, ClienteNome = "Maria Santos", Data = DateTime.Parse("2024-01-15"), Status = "Processando", Total = 67.90m }
                }
            };
            return View(viewModel);
        }
    }
}