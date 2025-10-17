using System.Collections.Generic;
using univesp_pi2.Models; // Necessário para usar a classe Product

namespace univesp_pi2.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public decimal VendasTotais { get; set; }
        public int TotalPedidos { get; set; }
        public int TotalClientes { get; set; }
        public int ProdutosBaixoEstoque { get; set; }
        public List<Product> ProdutosMaisVendidos { get; set; } = new();
        public List<PedidoViewModel> PedidosRecentes { get; set; } = new();
    }
}