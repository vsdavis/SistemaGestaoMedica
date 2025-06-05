using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoMedica.Models
{
    public class Medicamento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do medicamento é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome do Medicamento")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O fabricante é obrigatório")]
        [StringLength(100, ErrorMessage = "O fabricante deve ter no máximo 100 caracteres")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Quantidade em Estoque")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa")]
        public int QuantidadeEstoque { get; set; }

        [Display(Name = "Data de Validade")]
        [DataType(DataType.Date)]
        public DateTime? DataValidade { get; set; }

        [Display(Name = "Medicamento Ativo?")]
        public bool Ativo { get; set; } = true;

        [Display(Name = "Tarja")]
        [StringLength(50)]
        public string Tarja { get; set; }

        [Display(Name = "Registro Anvisa")]
        [StringLength(50)]
        public string RegistroAnvisa { get; set; }
    }
}