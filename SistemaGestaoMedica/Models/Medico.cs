namespace SistemaGestaoMedica.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int CPF { get; set; }
        public string? Especialidade { get; set; }
        public string? CRM { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Tipo { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
    }
}
