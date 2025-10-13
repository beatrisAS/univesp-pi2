using System;
using System.Collections.Generic;

namespace univesp_pi2.Models
{
    public class OrderViewModel
    {
        public string OrderId { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty;
        public int ItemCount { get; set; }
        public List<string> Products { get; set; } = new();
        public decimal TotalPrice { get; set; }
    }
}