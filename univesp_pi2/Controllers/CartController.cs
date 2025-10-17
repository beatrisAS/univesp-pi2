using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Models;
using univesp_pi2.Helpers;
using System.Linq;
using System.Collections.Generic;

public class CartController : Controller
{
    public IActionResult Index()
    {
        var cart = HttpContext.Session.Get<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
        var viewModel = new CartViewModel { Items = cart };
        return View(viewModel);
    }

    [HttpPost]
    public JsonResult AddToCart([FromBody] CartItemViewModel newItem)
    {
        var cart = HttpContext.Session.Get<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
        var existingItem = cart.FirstOrDefault(i => i.ProductId == newItem.ProductId);

        if (existingItem != null)
        {
            existingItem.Quantity += newItem.Quantity > 0 ? newItem.Quantity : 1;
        }
        else
        {
            if (newItem.Quantity == 0) newItem.Quantity = 1;
            cart.Add(newItem);
        }

        HttpContext.Session.Set("Cart", cart);
        return Json(new { success = true, message = "Produto adicionado!" });
    }


    [HttpGet]
    public JsonResult GetCartCount()
    {
        var cart = HttpContext.Session.Get<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
        return Json(new { count = cart.Count });
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
    
