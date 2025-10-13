using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using univesp_pi2.Helpers;
using System.Linq;

namespace univesp_pi2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName)) { return RedirectToAction("Index", "Login"); }
            var viewModel = GetMockAccountData(userName);
            ViewData["Title"] = "Minha Conta";
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditProfile([FromBody] ProfileViewModel model)
        {
            if (ModelState.IsValid) { Console.WriteLine($"Salvando perfil para: {model.FullName}"); return Json(new { success = true, message = "Perfil atualizado com sucesso!" }); }
            return Json(new { success = false, message = "Dados inválidos." });
        }
        
        [HttpPost]
        public IActionResult EditAddress([FromBody] AddressViewModel model)
        {
            if (model != null) { Console.WriteLine($"Salvando endereço: {model.Title}"); return Json(new { success = true, message = "Endereço salvo com sucesso!" }); }
            return Json(new { success = false, message = "Dados inválidos." });
        }

        [HttpPost]
        public IActionResult DeleteAddress([FromBody] DeleteAddressRequest request)
        {
             if (request != null) { Console.WriteLine($"Excluindo endereço: {request.Title}"); return Json(new { success = true, message = "Endereço excluído com sucesso!" }); }
            return Json(new { success = false, message = "Dados inválidos." });
        }

        public class DeleteAddressRequest { public string Title { get; set; } = string.Empty; }
        
        [HttpGet]
        public IActionResult Register() { return View(new RegisterViewModel()); }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model) { if (ModelState.IsValid) { return RedirectToAction("Index", "Login"); } return View(model); }

        private AccountViewModel GetMockAccountData(string userName)
        {
            bool isAdmin = (userName.ToLower() == "admin");
            var dynamicOrders = HttpContext.Session.Get<List<OrderViewModel>>("UserOrders") ?? new List<OrderViewModel>();
            var model = new AccountViewModel
            {
                Profile = new ProfileViewModel { FullName = isAdmin ? "Administrador" : "João Silva", Email = isAdmin ? "admin@ml3.com" : "joao@exemplo.com", Phone = "(11) 98765-4321", Cpf = "123.456.789-00", BirthDate = "10/05/1990", IsAdmin = isAdmin },
                Orders = dynamicOrders.OrderByDescending(o => o.Date).ToList(),
                Addresses = new List<AddressViewModel> { new AddressViewModel { Title = "Principal", Street = "Rua das Flores", Number = "123", Complement = "Apto 45", Neighborhood = "Centro", City = "São Paulo", State = "SP", Cep = "01234-567", IsPrimary = true }, new AddressViewModel { Title = "Trabalho", Street = "Av. Paulista", Number = "1000", Complement = "Sala 102", Neighborhood = "Bela Vista", City = "São Paulo", State = "SP", Cep = "01310-100", IsPrimary = false } }
            };
            if (isAdmin) { model.SupplierOrders = new List<SupplierOrderViewModel> { new SupplierOrderViewModel { OrderId = "FORN-01", OrderDate = new DateTime(2025, 10, 1), SupplierName = "Bosch Brasil", ItemCount = 50, TotalCost = 15000.00m, Status = "Recebido" }, new SupplierOrderViewModel { OrderId = "FORN-02", OrderDate = new DateTime(2025, 10, 8), SupplierName = "NGK do Brasil", ItemCount = 100, TotalCost = 8500.00m, Status = "Aguardando Envio" } }; }
            return model;
        }
    }
}