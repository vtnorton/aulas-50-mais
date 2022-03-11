using Xunit;
using BancoRoxinho.Dominio.Model;

namespace BancoRoxinho.Dominio.Test
{
    public class PessoaJuridicaTest
    {
        [Fact]
        public void DeveRetornarTrueQuandoOCNPJForValido()
        {
            string cnpj = "22091135000142";
            bool resultadoEsperado = true;
            PessoaJuridica pessoa = new PessoaJuridica();

            var resultado = pessoa.VerificaCNPJ(cnpj);

            Assert.True(resultado == resultadoEsperado);

        }

        [Fact]
        public void DeveRetornarFalseQuandoOCNPJForInvalido()
        {
            string cnpj = "22.091.135/2201-42";
            bool resultadoEsperado = false;
            PessoaJuridica pessoa = new PessoaJuridica();

            var resultado = pessoa.VerificaCNPJ(cnpj);

            Assert.True(resultado == resultadoEsperado);

        }
    }
}
