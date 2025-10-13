using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Helpers;
using univesp_pi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace univesp_pi2.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Finalizar Compra";
            return View();
        }

        [HttpPost]
        public IActionResult FinalizeOrder()
        {
            var cart = HttpContext.Session.Get<List<CartItemViewModel>>("Cart");
            if (cart == null || !cart.Any())
            {
                return Json(new { success = false, message = "Seu carrinho está vazio." });
            }

            var newOrder = new OrderViewModel
            {
                OrderId = $"PED-{new Random().Next(100, 999)}",
                Date = DateTime.Now,
                Status = "Em Processamento",
                ItemCount = cart.Sum(item => item.Quantity),
                Products = cart.Select(item => item.Name).ToList(),
                TotalPrice = cart.Sum(item => item.TotalPrice)
            };

            var orders = HttpContext.Session.Get<List<OrderViewModel>>("UserOrders") ?? new List<OrderViewModel>();
            orders.Add(newOrder);
            HttpContext.Session.Set("UserOrders", orders);
            HttpContext.Session.Remove("Cart");
            return Json(new { success = true, message = "Pedido finalizado com sucesso!" });
        }
    }
}