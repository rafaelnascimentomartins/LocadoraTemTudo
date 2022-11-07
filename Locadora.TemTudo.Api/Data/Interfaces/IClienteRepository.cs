using Locadora.TemTudo.Api.Models;

namespace Locadora.TemTudo.Api.Data.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> BuscarClientes();
        void Adicionar(Cliente model);
        void Editar(Cliente model);
    }
}
