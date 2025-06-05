using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoMedica.Models
{
    public class Medico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]+$", ErrorMessage = "O nome só pode conter letras e espaços")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido. Formato esperado: XXX.XXX.XXX-XX")]
        [StringLength(14)]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória")]
        [StringLength(50)]
        public string? Especialidade { get; set; }

        [Required(ErrorMessage = "O CRM é obrigatório")]
        [StringLength(20)]
        public string? CRM { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório")]
        [StringLength(20)]
        public string? Tipo { get; set; } = "Medico"; // Definindo padrão se quiser

        [Phone(ErrorMessage = "Telefone inválido")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Telefone inválido. Formato esperado: (XX) XXXX-XXXX ou (XX) XXXXX-XXXX")]
        public string? Telefone { get; set; }

        [StringLength(200)]
        public string? Endereco { get; set; }

        [StringLength(100)]
        public string? Cidade { get; set; }

        [StringLength(2, ErrorMessage = "Estado deve ter 2 caracteres (ex.: SP)")]
        public string? Estado { get; set; }
    }
}
