using BancoRoxinho.Dominio.Model;
using Microsoft.EntityFrameworkCore;

namespace BancoRoxinho.Dominio.Dados
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<Transacoes> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=BaseDeDados03;Integrated Security=SSPI");
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=Banco01;Integrated Security=SSPI");
        }
    }
}
