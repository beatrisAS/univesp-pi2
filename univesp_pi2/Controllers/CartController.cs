using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Models;
using System.Collections.Generic;
using System.Linq;
using univesp_pi2.Helpers;

namespace univesp_pi2.Controllers
{
    public class CartController : Controller
    {
        private readonly List<Product> _products;
        public CartController() { _products = GetProductsMock(); }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
            var viewModel = new CartViewModel { Items = cart };
            const decimal freeShippingThreshold = 199.00m;
            const decimal standardShippingCost = 29.90m;
            if (viewModel.Subtotal >= freeShippingThreshold) { viewModel.Shipping = 0; viewModel.FreeShippingMessage = "Você ganhou frete grátis!"; }
            else { viewModel.Shipping = standardShippingCost; viewModel.FreeShippingMessage = $"Frete grátis para compras acima de {freeShippingThreshold:C}"; }
            ViewData["Title"] = "Carrinho de Compras";
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null) return NotFound();
            var cart = HttpContext.Session.Get<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
            var cartItem = cart.FirstOrDefault(i => i.ProductId == productId);
            if (cartItem != null) { cartItem.Quantity += quantity; }
            else { cart.Add(new CartItemViewModel { ProductId = product.Id, Name = product.Name, Brand = product.Brand, ImageUrl = product.ImageUrl, UnitPrice = product.FinalPrice, Quantity = quantity }); }
            HttpContext.Session.Set("Cart", cart);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] UpdateQuantityRequest request)
        {
            var cart = HttpContext.Session.Get<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
            var item = cart.FirstOrDefault(i => i.ProductId == request.ProductId);
            if (item != null && request.Quantity > 0) { item.Quantity = request.Quantity; HttpContext.Session.Set("Cart", cart); return Json(new { success = true }); }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult RemoveFromCart([FromBody] RemoveFromCartRequest request)
        {
            var cart = HttpContext.Session.Get<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
            var item = cart.FirstOrDefault(i => i.ProductId == request.ProductId);
            if (item != null) { cart.Remove(item); HttpContext.Session.Set("Cart", cart); return Json(new { success = true }); }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart");
            return Json(new { success = true });
        }
        
        public class UpdateQuantityRequest { public int ProductId { get; set; } public int Quantity { get; set; } }
        public class RemoveFromCartRequest { public int ProductId { get; set; } }
        
        private List<Product> GetProductsMock()
        {
             return new List<Product> { new Product { Id = 1, Name = "Bateria Automotiva 60Ah", Price = 350.00m, DiscountPrice = 289.90m, ImageUrl = "/images/Bateria Automotiva 60Ah.png" }, new Product { Id = 2, Name = "Pastilha de Freio Dianteira", Price = 120.00m, DiscountPrice = 89.90m, ImageUrl = "/images/Pastilha de Freio Dianteira.png" }, new Product { Id = 5, Name = "Filtro de Óleo do Motor", Price = 32.00m, DiscountPrice = 24.90m, ImageUrl = "/images/Filtro de Óleo do Motor.png" } };
        }
    }
}