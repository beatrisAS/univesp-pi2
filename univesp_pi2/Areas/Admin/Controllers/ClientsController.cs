using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Areas.Admin.Models;

namespace univesp_pi2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
           
            var clients = new List<ClientViewModel>
            {
                new ClientViewModel { Id = 1, Name = "João da Silva", Email = "joao.silva@email.com", JoinDate = new DateTime(2024, 1, 10), TotalOrders = 5 },
                new ClientViewModel { Id = 2, Name = "Maria Santos", Email = "maria.santos@email.com", JoinDate = new DateTime(2024, 2, 15), TotalOrders = 8 },
                new ClientViewModel { Id = 3, Name = "Carlos Oliveira", Email = "carlos.o@email.com", JoinDate = new DateTime(2024, 3, 20), TotalOrders = 2 },
                new ClientViewModel { Id = 4, Name = "Ana Costa", Email = "ana.costa@email.com", JoinDate = new DateTime(2024, 4, 25), TotalOrders = 12 },
                new ClientViewModel { Id = 5, Name = "Pedro Mendes", Email = "pedro.mendes@email.com", JoinDate = new DateTime(2024, 5, 30), TotalOrders = 1 }
            };
            
           
           
            return View(clients);
        }
    }
}