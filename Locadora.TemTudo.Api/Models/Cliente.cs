using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.TemTudo.Api.Models
{
    public class Cliente
    {
        //Definindo campom Id como Identity(auto incremental), obrigatório e primary key
        [Key]
        public int Id { get; set; }
        //Definindo campo Nome como obrigatório e quantidade máx. de caracteres 100.

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required, MaxLength(11)]
        public string CPF { get; set; }

        [Required, MaxLength(80)]
        public string Email { get; set; }

        //Definindo campo TelefoneFixo como não obrigatório.
        public string? TelefoneFixo { get; set; }
        public string? Celular { get; set; }

        public List<ClienteEndereco> Enderecos { get; set; }
    }
}
