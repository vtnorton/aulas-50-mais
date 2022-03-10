using BancoRoxinho.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BancoRoxinho.Dominio.Dados
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<Transacoes> Transacoes { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public IEnumerable<object> PessoasJuridica { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=BaseDeDados05;Integrated Security=SSPI");
        }
    }
}
