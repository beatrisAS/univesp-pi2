using System.Collections.Generic;
using System.Linq;

namespace univesp_pi2.Models
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new();
        public decimal Subtotal => Items.Sum(i => i.TotalPrice);
        public decimal Shipping { get; set; }
        public string FreeShippingMessage { get; set; } = string.Empty;
        public decimal Total => Subtotal + Shipping;
    }
}