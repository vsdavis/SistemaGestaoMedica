using Microsoft.AspNetCore.Mvc;
using SistemaGestaoMedica.Models;

namespace SistemaGestaoMedica.Controllers
{
    public class MedicosController : Controller
    {
        // GET: Medicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                // Aqui você vai adicionar o médico ao banco de dados (ex.: context.Add(medico))
                // E salvar as alterações
                // Exemplo fictício:
                // _context.Medicos.Add(medico);
                // _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        // GET: Medicos
        public IActionResult Index()
        {
            // Aqui você listaria os médicos cadastrados.
            return View();
        }
    }
}
