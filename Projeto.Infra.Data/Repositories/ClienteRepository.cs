using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        //atributo..
        private readonly SqlServerContext context;

        //construtor para injeção de dependência
        public ClienteRepository(SqlServerContext context)
            : base(context) //construtor da superclasse
        {
            this.context = context;
        }

        public Cliente GetByEmail(string email)
        {
            return context.Clientes
                    .FirstOrDefault(c => c.Email.Equals(email));
        }

        public Cliente GetByCpf(string cpf)
        {
            return context.Clientes
                    .FirstOrDefault(c => c.Cpf.Equals(cpf));
        }
    }
}
