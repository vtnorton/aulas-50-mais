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
            var pessoa = new PessoaFisica();
            pessoa.Idade = 35;
            bool resultadoEsperado = true;
            
            // executar o programa
            bool resultado = pessoa.MaiorIdade;

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoForMenorDeIdade()
        {
            // definir o que vai ser testado
            var pessoa = new PessoaFisica();
            pessoa.Idade = 15;
            bool resultadoEsperado = false;

            // executar o programa
            bool resultado = pessoa.MaiorIdade;

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoDezoitoAnos()
        {
            // definir o que vai ser testado
            var pessoa = new PessoaFisica();
            pessoa.Idade = 18;
            bool resultadoEsperado = true;

            // executar o programa
            bool resultado = pessoa.MaiorIdade;

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

        [Fact]
        public void DeveRetornarTrueParaCpfValido()
        {
            // definir o que vai ser testado
            string cpf = "923.889.610-09";
            bool resultadoEsperado = true;
            var pessoa = new PessoaFisica();

            // executar o programa
            bool resultado = pessoa.VerificarCPF(cpf);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

        [Fact]
        public void DeveRetornarFalseParaCpfInvalido()
        {
            // definir o que vai ser testado
            string cpf = "114.215.838-11";
            bool resultadoEsperado = false;
            var pessoa = new PessoaFisica();

            // executar o programa
            bool resultado = pessoa.VerificarCPF(cpf);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }
    }
}
