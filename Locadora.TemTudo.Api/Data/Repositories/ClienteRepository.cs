using Locadora.TemTudo.Api.Data.Interfaces;
using Locadora.TemTudo.Api.Models;

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
    }
}
