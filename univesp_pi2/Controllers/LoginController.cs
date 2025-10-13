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
            
                const string usuario_teste = "joao@exemplo.com";
                const string senha_teste = "123456";
                
               
                const string usuario_admin = "admin@ml3.com";
                const string senha_admin = "admin123";

                if (login.User == usuario_teste && login.Password == senha_teste)
                {
                
                    HttpContext.Session.SetString("UserName", "João"); 
                    return RedirectToAction("Index", "Home");
                }
                else if (login.User == usuario_admin && login.Password == senha_admin)
                {
              
                    HttpContext.Session.SetString("UserName", "Admin");
                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
                }
            }
            
            return View("Index", login);
        }

        
        [HttpGet]
        public IActionResult Logout()
        {
      
            HttpContext.Session.Clear(); 
            
           
           
            return RedirectToAction("Index", "Home");
        }
    }
}