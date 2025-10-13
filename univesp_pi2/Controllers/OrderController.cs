using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Areas.Admin.Models;
using System.Collections.Generic; 

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

       
        public IActionResult Invoice(string orderId)
        {
          
            var supplierOrder = new univesp_pi2.Models.SupplierOrderViewModel 
            {
                OrderId = orderId,
                OrderDate = DateTime.Now.AddDays(-5),
                SupplierName = "Fornecedor Mockup",
                ItemCount = 2,
                TotalCost = 275.00m
            };

            ViewData["Title"] = $"Nota Fiscal - Pedido {orderId}";

          
            var htmlContent = $@"
                <html>
                <head>
                    <title>{ViewData["Title"]}</title>
                    <style>
                        body {{ font-family: Arial, sans-serif; padding: 20px; }}
                        .invoice {{ border: 1px solid #ccc; padding: 20px; max-width: 800px; margin: 0 auto; }}
                        h2 {{ text-align: center; }}
                        .info p {{ margin: 5px 0; }}
                        table {{ width: 100%; border-collapse: collapse; margin-top: 20px; }}
                        th, td {{ border: 1px solid #ccc; padding: 8px; text-align: left; }}
                        .total {{ text-align: right; font-weight: bold; font-size: 1.2em; margin-top: 10px; }}
                    </style>
                </head>
                <body>
                    <div class='invoice'>
                        <h2>NOTA FISCAL DE ENTRADA</h2>
                        <div class='info'>
                            <p><strong>Número do Pedido:</strong> {supplierOrder.OrderId}</p>
                            <p><strong>Data de Emissão:</strong> {supplierOrder.OrderDate.ToString("dd/MM/yyyy")}</p>
                            <p><strong>Fornecedor:</strong> {supplierOrder.SupplierName}</p>
                            <p><strong>Valor Total:</strong> {supplierOrder.TotalCost.ToString("C")}</p>
                        </div>
                        <h3>Itens</h3>
                        <table>
                            <thead>
                                <tr><th>Qtde</th><th>Descrição</th></tr>
                            </thead>
                            <tbody>
                                <tr><td>{supplierOrder.ItemCount}</td><td>Produtos diversos de estoque</td></tr>
                            </tbody>
                        </table>
                    </div>
                </body>
                </html>";

            return Content(htmlContent, "text/html");
        }
    }
}