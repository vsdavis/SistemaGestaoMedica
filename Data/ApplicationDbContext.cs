using Microsoft.EntityFrameworkCore;
using SistemaGestaoMedica.Models;

namespace SistemaGestaoMedica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Recepsionista> Recepsionistas { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

    }
}
