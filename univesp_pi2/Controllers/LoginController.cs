using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Models;

namespace univesp_pi2.Controllers
{
    public class LoginController : Controller
    {
    
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

   
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                const string usuario_teste = "teste@ml3pecas.com";
                const string senha_teste = "123456";

                if (login.User == usuario_teste && login.Password == senha_teste)
                {
               
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                   
                    ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
                }
            }

         
            return View("Index", login);
        }
    }
}