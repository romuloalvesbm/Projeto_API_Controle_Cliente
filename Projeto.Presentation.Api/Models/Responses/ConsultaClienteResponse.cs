using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Models.Responses
{
    public class ConsultaClienteResponse
    {
        public int StatusCode { get; set; }
        public List<Cliente> Data { get; set; }
    }
}
