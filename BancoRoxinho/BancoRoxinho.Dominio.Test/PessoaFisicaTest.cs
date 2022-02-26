using BancoRoxinho.Dominio.Model;
using Xunit; //FluentAssertion 
             //FakeItEasy 
             //BUGUS

namespace BancoRoxinho.Dominio.Test
{
    public class PessoaFisicaTest
    {
        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoForMaiorDeDezoito()
        {
            // definir o que vai ser testado
            int idade = 26;
            bool resultadoEsperado = true;
            var pessoa = new PessoaFisica();

            pessoa.Nome = "Vitor";
            pessoa.Sobrenome = "Norton";
            pessoa.Idade = 26;

            // executar o programa
            bool resultado = pessoa.VerificarMaioridade(pessoa);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoForMenorDeIdade()
        {
            // definir o que vai ser testado
            bool resultadoEsperado = false;
            var pessoa = new PessoaFisica();

            pessoa.Nome = "Vitor";
            pessoa.Sobrenome = "Norton";
            pessoa.Idade = 10;

            // executar o programa
            bool resultado = pessoa.VerificarMaioridade(pessoa);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoDezoitoAnos()
        {
            // definir o que vai ser testado
            bool resultadoEsperado = true;
            var pessoa = new PessoaFisica();

            pessoa.Nome = "Vitor";
            pessoa.Sobrenome = "Norton";
            pessoa.Idade = 18;

            // executar o programa
            bool resultado = pessoa.VerificarMaioridade(pessoa);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }
    }
}