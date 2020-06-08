using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Models.Responses
{
    public class EdicaoClienteResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Cliente Data { get; set; }
    }
}
