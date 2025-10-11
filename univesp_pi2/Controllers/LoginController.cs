using Microsoft.AspNetCore.Mvc;
using univesp_pi2.Models;

namespace univesp_pi2.Controllers
{
    public class LoginController : Controller
    {
      
        public IActionResult Index()
        {
            
            return View("Index", new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
          
            {
                
                return View("Index", login); 
            }

       
            const string usuario_teste = "teste@ml3pecas.com";
            const string senha_teste = "123456";

            if (login.User == usuario_teste && login.Password == senha_teste)
            {
                
                
            
                return RedirectToAction("Index", "Home");
            }
            else
            {
               
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos. Por favor, tente novamente.");
                
                
                return View("Index", login);
            }
        }
    }
}
