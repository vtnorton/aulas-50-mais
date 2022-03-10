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
            int idade = 26;
            bool resultadoEsperado = true;
            var pessoa = new PessoaJuridica();

            pessoa.Nome = "Vitor";
            pessoa.Sobrenome = "Norton";

            // executar o programa
            bool resultado = pessoa.VerificarMaioridade(idade);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoForMenorDeIdade()
        {
            // definir o que vai ser testado
            int idade = 10;
            bool resultadoEsperado = false;
            var pessoa = new PessoaJuridica();

            // executar o programa
            bool resultado = pessoa.VerificarMaioridade(idade);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoDezoitoAnos()
        {
            // definir o que vai ser testado
            int idade = 18;
            bool resultadoEsperado = true;
            var pessoa = new PessoaJuridica();

            // executar o programa
            bool resultado = pessoa.VerificarMaioridade(idade);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }
    }
}
