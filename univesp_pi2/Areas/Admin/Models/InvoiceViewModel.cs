using System;
using System.Collections.Generic;
using System.Linq;

namespace univesp_pi2.Areas.Admin.Models
{
    public class InvoiceViewModel
    {
        public string OrderId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string SupplierAddress { get; set; } = string.Empty;
        public string SupplierCnpj { get; set; } = string.Empty;

        public List<InvoiceItemViewModel> Items { get; set; } = new();

        
        public decimal Subtotal => Items.Sum(i => i.Total);
        public decimal Taxes => Subtotal * 0.18m; 
        public decimal Total => Subtotal + Taxes;
    }
}