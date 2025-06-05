using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoMedica.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]+$", ErrorMessage = "O nome só pode conter letras e espaços")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(14)]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido. Formato esperado: XXX.XXX.XXX-XX")]
        public string CPF { get; set; } = null!;


        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Telefone inválido")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Telefone inválido. Formato esperado: (XX) XXXX-XXXX ou (XX) XXXXX-XXXX")]
        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public string? PlanoSaude { get; set; }
        public string? PlanoCodigo { get; set; }
        public string? PlanoValidade { get; set; }
        public string? PlanoCobertura { get; set; }
        public string? DoencasCronicas { get; set; }
        public string? alergias { get; set; }
        public string? medicamentos { get; set; }
        public string? cirurgias { get; set; }
        public string? observacoes { get; set; }
        public string? ContatoEmergencia { get; set; }
    }
}
