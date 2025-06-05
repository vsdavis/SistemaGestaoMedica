using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoMedica.Data;
using SistemaGestaoMedica.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoMedica.Controllers
{
    public class AgendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(DateTime? data)
        {
            var dataFiltro = data ?? DateTime.Today;

            var agendamentos = await _context.Agendamentos
                .AsNoTracking()
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .Where(a => a.DataAgendamento.Date == dataFiltro.Date)
                .OrderBy(a => a.Horario)
                .ToListAsync();

            ViewData["DataSelecionada"] = dataFiltro.ToString("yyyy-MM-dd");
            return View(agendamentos);
        }

        public async Task<IActionResult> DetalharAtendimento(int? id, DateTime? data, TimeSpan? horario, int? medicoId)
        {
            if (id == null)
            {
                var model = new Agendamento
                {
                    DataAgendamento = (data ?? DateTime.Today).ToUniversalTime(), // Converter para UTC
                    Horario = horario ?? TimeSpan.FromHours(9),
                    MedicoId = medicoId ?? 1
                };

                await CarregarViewData(model);
                ViewData["Title"] = "Novo Agendamento";
                return View(model);
            }

            var agendamento = await _context.Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (agendamento == null)
            {
                return NotFound();
            }

            // Converter para horário local para exibição
            agendamento.DataAgendamento = agendamento.DataAgendamento.ToLocalTime();

            await CarregarViewData(agendamento);
            ViewData["Title"] = "Editar Agendamento";
            return View(agendamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetalharAtendimento(int id, Agendamento agendamento)
        {
            if (id != agendamento.Id && id != 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Converter para UTC antes de salvar
                    agendamento.DataAgendamento = agendamento.DataAgendamento.ToUniversalTime();

                    if (id == 0)
                    {
                        agendamento.DataCriacao = DateTime.UtcNow; // Usar UTC
                        _context.Add(agendamento);
                    }
                    else
                    {
                        agendamento.DataAtualizacao = DateTime.UtcNow; // Usar UTC
                        _context.Update(agendamento);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { data = agendamento.DataAgendamento.ToLocalTime().ToString("yyyy-MM-dd") });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoExists(agendamento.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Ocorreu um erro: {ex.Message}");
                }
            }

            await CarregarViewData(agendamento);
            return View(agendamento);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var agendamento = await _context.Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (agendamento == null) return NotFound();

            // Converter para horário local para exibição
            agendamento.DataAgendamento = agendamento.DataAgendamento.ToLocalTime();

            return View(agendamento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null) return NotFound();

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamentos.Any(e => e.Id == id);
        }

        private async Task CarregarViewData(Agendamento agendamento)
        {
            ViewData["Pacientes"] = await _context.Pacientes
                .Select(p => new { p.Id, p.Nome })
                .ToListAsync();

            ViewData["Medicos"] = await _context.Medicos
                .Select(m => new { m.Id, m.Nome, m.Especialidade })
                .ToListAsync();

            ViewData["TiposConsulta"] = Enum.GetValues(typeof(TipoConsulta))
                .Cast<TipoConsulta>()
                .Select(t => new { Value = t, Text = t.ToString() })
                .ToList();
        }
    }
}