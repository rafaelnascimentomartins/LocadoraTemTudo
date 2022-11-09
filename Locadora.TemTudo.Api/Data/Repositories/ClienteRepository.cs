using Locadora.TemTudo.Api.Data.Interfaces;
using Locadora.TemTudo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.TemTudo.Api.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private LocadoraContext _ctx;

        public ClienteRepository(LocadoraContext ctx)
        {
            _ctx = ctx;
        }
        public List<Cliente> BuscarClientes()
        {
            //Select * from Clientes
            return _ctx.Clientes.ToList();
        }

        public void Adicionar(Cliente model)
        {
            //INSERT INTO Clientes (campos...) VALUES (valores no objeto 'model')
            _ctx.Clientes.Add(model);
            _ctx.SaveChanges();
        }

        public void Editar(Cliente model)
        {
            //UPDATE Clientes SET (campos... e valores...) WHERE Id = model.Id
            _ctx.Update(model);
            _ctx.SaveChanges();
        }

        public Cliente BuscarPorId(int id)
        {
            return _ctx.Clientes
                .Include(i => i.Enderecos)
                .FirstOrDefault(w => w.Id.Equals(id));
        }

        public void Remover(Cliente model)
        {
            _ctx.Clientes.Remove(model);
        }

        public void RemoverEnderecos(List<ClienteEndereco> enderecos)
        {
            _ctx.ClientesEnderecos.RemoveRange(enderecos);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
