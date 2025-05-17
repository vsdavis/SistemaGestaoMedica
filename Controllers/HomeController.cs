using Microsoft.AspNetCore.Mvc;

namespace SistemaGestaoMedica.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
