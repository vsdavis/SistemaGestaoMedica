using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoMedica.Data;
using SistemaGestaoMedica.Models;

public class PacientesController : Controller
{
    private readonly ApplicationDbContext _context;

    public PacientesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Pacientes
    public async Task<IActionResult> Index(string cpf = "", string nome = "")
    {
        var query = _context.Pacientes.AsQueryable();

        if (!string.IsNullOrWhiteSpace(cpf))
            query = query.Where(p => p.CPF != null && p.CPF.Contains(cpf));

        if (!string.IsNullOrWhiteSpace(nome))
            query = query.Where(p => p.Nome != null && p.Nome.Contains(nome));

        var pacientes = await query.ToListAsync();
        return View(pacientes);
    }

    // GET: Pacientes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Pacientes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Paciente paciente)
    {
        Console.WriteLine("===> MÉTODO CREATE POST");
        Console.WriteLine($"Nome: {paciente.Nome ?? "[null]"}, CPF: {paciente.CPF ?? "[null]"}");

        if (ModelState.IsValid)
        {
            _context.Add(paciente);
            await _context.SaveChangesAsync();
            Console.WriteLine("===> PACIENTE SALVO");
            return RedirectToAction(nameof(Index));
        }

        Console.WriteLine("===> MODELSTATE INVÁLIDO");
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine($"Erro: {error.ErrorMessage}");
        }

        return View(paciente);
    }
}
