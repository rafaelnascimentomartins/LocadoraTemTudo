using System.ComponentModel.DataAnnotations;

namespace Locadora.TemTudo.Api.Models
{
    public class LogErro
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(500)]
        public string StackTrace { get; set; }

        [Required, MaxLength(200)]
        public string Mensagem { get; set; }

        [MaxLength(500)]
        public string? InnerException { get; set; }

        [Required]
        public DateTime DataHoraRegistro { get; set; }
    }
}
