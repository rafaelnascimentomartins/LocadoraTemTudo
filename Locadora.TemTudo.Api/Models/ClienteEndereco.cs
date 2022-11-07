using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.TemTudo.Api.Models
{
    public class ClienteEndereco
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Logradouro { get; set; }

        [Required, MaxLength(200)]
        public string Bairro { get; set; }

        [Required, MaxLength(200)]
        public string CEP { get; set; }

        [MaxLength(200)]
        public string? Complemento { get; set; }

        [Required, MaxLength(200)]
        public string Numero { get; set; }

        [MaxLength(200)]
        public string? PontoReferencia { get; set; }


        //COMENTADO, POIS O ENTITY NA VERSÃO .NET 6, CRIA AUTOMÁTICAMENTE A RELAÇÃO, APENAS COLOCANDO A LISTA NA CLASSE Cliente.
        //Definindo campo para ligação com tabela de Clientes! FK
        // NO BANCO: FOREIGN KEY (IdCliente) REFERENCES Clientes (Id)
        //[Required]
        //public int IdCliente { get; set; }

        //[ForeignKey("IdCliente")]
        //public Cliente Cliente { get; set; }
    }
}
