using System.Collections.Generic;
using System.Linq;

namespace univesp_pi2.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new();
        public decimal Subtotal => Items.Sum(i => i.TotalPrice);
        
  
        private const decimal FreeShippingThreshold = 199.00m;
        private const decimal StandardShippingCost = 29.90m;
        public decimal Shipping => Subtotal >= FreeShippingThreshold ? 0 : StandardShippingCost;
        public decimal Total => Subtotal + Shipping;
    }
}