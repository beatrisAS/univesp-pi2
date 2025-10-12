using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Models;

namespace univesp_pi2.Controllers
{
    public class AccountController : Controller
    {
       
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

       
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }
    }
}