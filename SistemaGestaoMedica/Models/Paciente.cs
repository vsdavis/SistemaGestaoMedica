using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SistemaGestaoMedica.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int CPF { get; set; }
    }
}

