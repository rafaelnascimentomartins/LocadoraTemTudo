using System.ComponentModel.DataAnnotations;

namespace Locadora.TemTudo.Api.DTOs
{
    public class ClienteDTO
    {
        //[Required(ErrorMessage="Campo Nome é obrigatório")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "Campo Data Nascimento é obrigatório")]
        public string DataNascimento { get; set; }

        //[Required(ErrorMessage = "Campo E-mail é obrigatório")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Campo CPF é obrigatório")]
        public string CPF { get; set; }
        public string CpfStr 
        { 
            get 
            {
                string retorno = string.Empty;

                if (!string.IsNullOrEmpty(CPF))
                {
                    //10004642709
                    var digit1 = CPF.Substring(0, 3);
                    var digit2 = CPF.Substring(3, 3);
                    var digit3 = CPF.Substring(6, 3);
                    var digit4 = CPF.Substring(9, 2);


                    retorno = $"{digit1}.{digit2}.{digit3}-{digit4}";
                }

                return retorno;
            } 
        }
    }
}
