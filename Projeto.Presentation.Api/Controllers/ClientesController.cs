using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using Projeto.Presentation.Api.Models.Requests;
using Projeto.Presentation.Api.Models.Responses;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        //atributo
        private readonly IClienteRepository clienteRepository;

        //construtor para injeção de dependência
        public ClientesController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroClienteResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroClienteRequest request)
        {
            var entity = new Cliente
            {
                Nome = request.Nome,
                Email = request.Email,
                Cpf = request.Cpf,
                DataCriacao = DateTime.Now
            };

            clienteRepository.Create(entity);

            var response = new CadastroClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente cadastrado com sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoClienteResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoClienteRequest request)
        {
            var entity = clienteRepository.GetById(request.IdCliente);

            //verificando se o cliente não foi encontrado
            if (entity == null)
                return UnprocessableEntity();

            entity.Nome = request.Nome;
            entity.Email = request.Email;
            entity.Cpf = request.Cpf;

            clienteRepository.Update(entity);

            var response = new EdicaoClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente atualizado com sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoClienteResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var entity = clienteRepository.GetById(id);

            //verificando se o cliente não foi encontrado
            if (entity == null)
                return UnprocessableEntity();

            clienteRepository.Delete(entity);

            var response = new EdicaoClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente excluído com sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaClienteResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = clienteRepository.GetAll()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaClienteResponse))]
        public IActionResult GetById(int id)
        {
            var response = new ConsultaClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Cliente>()
            };

            response.Data.Add(clienteRepository.GetById(id));
            return Ok(response);
        }
    }
}