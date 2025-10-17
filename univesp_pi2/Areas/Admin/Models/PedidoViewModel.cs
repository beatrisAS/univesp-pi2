using System;

namespace univesp_pi2.Areas.Admin.Models
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}