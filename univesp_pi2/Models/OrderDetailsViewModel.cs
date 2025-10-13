using System;
using System.Collections.Generic;

namespace univesp_pi2.Models
{
    public class OrderDetailsViewModel
    {
        public string OrderId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public AddressViewModel ShippingAddress { get; set; } = new();
        public List<CartItemViewModel> Items { get; set; } = new();
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Total { get; set; }
    }
}