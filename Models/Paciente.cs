using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoMedica.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int CPF { get; set; }
        public string? PlanoSaude { get; set; }
        public string? PlanoCodigo { get; }
        public string? PlanoValidade { get; set; }
        public string? PlanoCobertura { get; set; }
        public string? doencasCronicas { get; set; }
        public string? alergias { get; set; }
        public string? medicamentos { get; set; }
        public string? cirurgias { get; set; }
        public string? observacoes { get; set; }
        public string? contatoEmergencia { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

    }
}

