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
        private readonly LogErroRepository _logRepository;
        private readonly string erroBadRequest = "Ocorreu uma falha interna, favor tente novamente mais tarde ou procure um dos nossos suportes!";
        public ClienteController(LocadoraContext ctx)
        {
            _clienteRepository = new(ctx);
            _logRepository = new(ctx);
        }

        /// <summary>
        /// HttpGet utilizado apenas para buscar informações
        /// http://localhost:3000/api/Cliente/BuscarClientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BuscarClientes()
        {
            try
            {
                var clientesBase = _clienteRepository.BuscarClientes();

                return Ok(clientesBase);
            }
            catch (Exception ex)
            {
                _logRepository.Adicionar(ex);
                return BadRequest(erroBadRequest);
            }
        }

        /// <summary>
        /// HttpPost utilizado apenas para "postar" registros (INCLUIR)
        ///  http://localhost:3000/api/Cliente/Adicionar (Internamente em Request: body carregado com a classe model)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adicionar(Cliente model)
        {
            try
            {
                //PROXIMA AULA CRIAR REGRAS, CONVERSÕES E VALIDAÇÕES
                _clienteRepository.Adicionar(model);

                return Ok();
            }
            catch (Exception ex)
            {
                _logRepository.Adicionar(ex);
                return BadRequest(erroBadRequest);
            }
           
        }

        /// <summary>
        /// HttpPut utilizado apenas para alterar registros (ALTERAR)
        /// http://localhost:3000/api/Cliente/Editar/1 (Internamente em Request: body carregado com a classe model)
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Editar(int id, Cliente mRequest)
        {
            try
            {
                //Necessário buscar o usuário com a referência do entity para edição do mesmo.
                var clienteBase = _clienteRepository.BuscarPorId(id);

                if(clienteBase == null)
                    return BadRequest($"Id: {id} não foi encontrado!");
                

                clienteBase.Nome = mRequest.Nome;
                clienteBase.TelefoneFixo = mRequest.TelefoneFixo;
                clienteBase.Celular = mRequest.Celular;
                clienteBase.CPF = mRequest.CPF;
                clienteBase.DataNascimento = mRequest.DataNascimento;
                clienteBase.Email = mRequest.Email;
                clienteBase.Enderecos = mRequest.Enderecos;


                _clienteRepository.Editar(clienteBase);

                return Ok();
            }
            catch (Exception ex)
            {
                _logRepository.Adicionar(ex);
                return BadRequest(erroBadRequest);
            }
        }

        /// <summary>
        /// HttpDelete utilizado apenas para remover um registro específico (REMOVER)
        /// http://localhost:3000/api/Cliente/Remover/1
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                var clienteBase = _clienteRepository.BuscarPorId(id);

                if (clienteBase == null)
                    return BadRequest($"Id: {id} não foi encontrado!");

                if (clienteBase.Enderecos != null && clienteBase.Enderecos.Count() > 0)
                    _clienteRepository.RemoverEnderecos(clienteBase.Enderecos);

                _clienteRepository.Remover(clienteBase);
                _clienteRepository.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                _logRepository.Adicionar(ex);
                return BadRequest(erroBadRequest);
            }
        }
    }
}
