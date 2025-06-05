using Microsoft.AspNetCore.Mvc;

namespace SistemaGestaoMedica.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetalharAtendimento()
        {
            // Aqui você redireciona para a tela de cadastro de atendimento (que vamos criar em seguida)
            return View();
        }
    }
}
