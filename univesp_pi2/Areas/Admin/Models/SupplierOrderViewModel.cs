using System;
using System.Collections.Generic;

namespace univesp_pi2.Models
{
    public class SupplierOrderViewModel
    {
        public string OrderId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public int ItemCount { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}