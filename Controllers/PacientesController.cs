using Microsoft.AspNetCore.Mvc;
using SistemaGestaoMedica.Models;
using SistemaGestaoMedica.Data;
using System;

namespace SistemaGestaoMedica.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           return View(_context.Pacientes.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // Editar, Detalhes, Excluir etc. podem ser adicionados depois
    }
}
