using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Areas.Admin.Models;

namespace univesp_pi2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller 
    { 
        public IActionResult Index()
        {
            var orders = new List<PedidoViewModel> {
                new PedidoViewModel { Id = 1, ClienteNome = "João Silva", Data = DateTime.Parse("2024-01-15"), Status = "Enviado", Total = 189.9m },
                new PedidoViewModel { Id = 2, ClienteNome = "Maria Santos", Data = DateTime.Parse("2024-01-15"), Status = "Processando", Total = 67.9m },
                new PedidoViewModel { Id = 3, ClienteNome = "Carlos Oliveira", Data = DateTime.Parse("2024-01-14"), Status = "Entregue", Total = 234.8m },
                new PedidoViewModel { Id = 4, ClienteNome = "Ana Costa", Data = DateTime.Parse("2024-01-14"), Status = "Cancelado", Total = 89.9m },
                new PedidoViewModel { Id = 5, ClienteNome = "Pedro Mendes", Data = DateTime.Parse("2024-01-13"), Status = "Enviado", Total = 156.9m }
            };
            return View(orders);
        }
    }
}