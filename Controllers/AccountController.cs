using Microsoft.AspNetCore.Mvc;

namespace SistemaGestaoMedica.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email e senha são obrigatórios!";
                return View();
            }

            if (email == "admin@admin.com" && password == "123456")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuário ou senha inválidos.";
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string name,string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                ViewBag.Error = "Todos os campos são obrigatorios!";
                return View();
            }
            if (password != confirmPassword)
            {
                ViewBag.Error = "As senhas não coincidem!";
                return View();
            }
            TempData["Success"] = "Usuário cadastrado com sucesso!";
            return RedirectToAction("Login");

        }
    }
}
