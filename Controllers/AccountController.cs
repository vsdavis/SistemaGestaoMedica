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
    }
}
