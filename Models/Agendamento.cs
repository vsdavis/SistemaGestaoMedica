using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoMedica.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        [Required]
        public DateTime DataAgendamento { get; set; }

        [Required]
        public TimeSpan Horario { get; set; }

        [Required]
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

        [Required]
        public int MedicoId { get; set; }
        public virtual Medico Medico { get; set; }

        [Required]
        public TipoConsulta TipoConsulta { get; set; }

        [StringLength(500)]
        public string Observacoes { get; set; }

        public bool Confirmado { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAtualizacao { get; set; }
    }

    public enum TipoConsulta
    {
        Consulta,
        Retorno,
        Exame,
        Urgencia
    }
}