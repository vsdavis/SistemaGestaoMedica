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
    }
}
