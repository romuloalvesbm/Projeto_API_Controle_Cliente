using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    public class SqlServerContext : DbContext
    {
        //REGRA 2) Construtor para inicializar a classe DbContext
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options) //construtor da superclasse (DbContext)
        {

        }

        //REGRA 3) Declarar uma propriedade DbSet para cada entidade do projeto
        public DbSet<Cliente> Clientes { get; set; } //CRUD..

        //REGRA 4) Sobrescrita (OVERRIDE) do método OnModelCreating
        //Utilizado para registrar todos os mapeamentos do projeto..
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //registrar cada classe de mapeamento do projeto..
            modelBuilder.ApplyConfiguration(new ClienteMap());

            //mapeamento de índices (UNIQUE)
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(c => c.Cpf).IsUnique();
                entity.HasIndex(c => c.Email).IsUnique();
            });
        }
    }
}
