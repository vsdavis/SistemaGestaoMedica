using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoMedica.Models
{
    public class Exame
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do exame é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do exame deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome do Exame")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Preparo Necessário")]
        [StringLength(500, ErrorMessage = "O preparo deve ter no máximo 500 caracteres")]
        public string PreparoNecessario { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; } = true;
    }
}