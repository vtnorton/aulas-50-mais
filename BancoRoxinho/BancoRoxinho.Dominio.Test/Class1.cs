using BancoRoxinho.Dominio.Dados;
using Xunit;

namespace BancoRoxinho.Dominio.Test
{
    public class Class1
    {
        [Fact]
        public void TesteAleatorio()
        {
            PessoasRepository pessoasRepository = new PessoasRepository();
            pessoasRepository.ObterPessoasFisicas();
        }
    }
}
