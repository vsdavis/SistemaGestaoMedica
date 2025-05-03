namespace SistemaGestaoMedica.Models
{
    public class Recepsionista
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int CPF { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Tipo { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public int CRM { get; set; }
    }
}
