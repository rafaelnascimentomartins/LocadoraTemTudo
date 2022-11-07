using Locadora.TemTudo.Api.Models;
using Locadora.TemTudo.Api.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Locadora.TemTudo.Api.Data;

namespace Locadora.TemTudo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;
        public ClienteController(LocadoraContext ctx)
        {
            _clienteRepository = new(ctx);
        }

        /// <summary>
        /// HttpGet utilizado apenas para buscar informações
        /// http://localhost:3000/api/Cliente/BuscarClientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BuscarClientes()
        {
            var clientesBase = _clienteRepository.BuscarClientes();

            return Ok(clientesBase);
        }

        /// <summary>
        /// HttpPost utilizado apenas para "postar" registros (INCLUIR)
        ///  http://localhost:3000/api/Cliente/Adicionar (Internamente em Request: body carregado com a classe model)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adicionar(Cliente model)
        {
            //PROXIMA AULA CRIAR REGRAS, CONVERSÕES E VALIDAÇÕES
            _clienteRepository.Adicionar(model);
            
            return Ok();
        }

        /// <summary>
        /// HttpPut utilizado apenas para alterar registros (ALTERAR)
        /// http://localhost:3000/api/Cliente/Editar/1 (Internamente em Request: body carregado com a classe model)
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Editar(int id, Cliente model)
        {
            try
            {
                model.Id = id;
                _clienteRepository.Editar(model);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
