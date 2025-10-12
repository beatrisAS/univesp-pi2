using univesp_pi2.Models; // Usando o modelo Product principal

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

    public class PedidoViewModel
    {
        public int Id { get; set; }
        public required string ClienteNome { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public required string Status { get; set; }
    }
}