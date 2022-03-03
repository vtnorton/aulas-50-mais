using BancoRoxinho.Dominio.Model;
using Xunit; //FluentAssertion 
             //FakeItEasy 
             //BUGUS

namespace BancoRoxinho.Dominio.Test
{
    public class PessoaJuridicaTest
    {
        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoForMaiorDeDezoito()
        {
            // definir o que vai ser testado
            int idadePJ = 80;
            bool resultadoEsperado = true;
            var pessoa = new PessoaJuridica();

            pessoa.NomePJ = "Pedro";
            pessoa.SobrenomePJ = "Nero";

            // executar o programa
            bool resultado = pessoa.VerificarMaioridade(idadePJ);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoForMenorDeIdade()
        {
            // definir o que vai ser testado
            int idadePJ = 10;
            bool resultadoEsperado = false;
            var pessoa = new PessoaJuridica();

            // executar o programa
            bool resultado = pessoa.VerificarMaioridade(idadePJ);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoDezoitoAnos()
        {
            // definir o que vai ser testado
            int idadePJ = 18;
            bool resultadoEsperado = true;
            var pessoa = new PessoaJuridica();

            // executar o programa
            bool resultado = pessoa.VerificarMaioridade(idadePJ);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }
    }
}
