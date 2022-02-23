using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;//fluentAssertion
//fakeiteasy
//BUGUS
using BancoRoxinho.Dominio.Model;


namespace BancoRoxinho.Dominio.Test
{
    
    public class PessoaFisicaTest
    {
        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoForMaiorDeDezoito()
        {
            //definir o que vai ser testado
            int idade = 26;
            bool resultadoEsperado = true;
            var pessoa = new PessoaFisica();
            //executar o programa
            var resultado = pessoa.VerificarMaioridade(idade);



            //validar o teste
            Assert.True(resultado == resultadoEsperado);
            
        }
        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoForMenorDeDezoito()
        {
            //definir o que vai ser testado
            int idade = 10;
            bool resultadoEsperado = false;
            var pessoa = new PessoaFisica();
            //executar o programa
            var resultado = pessoa.VerificarMaioridade(idade);



            //validar o teste
            Assert.True(resultado == resultadoEsperado);

        }
        [Fact]
        public void DeveValidarIdadeDaPessoaQuandoForIgualDezoito()
        {
            //definir o que vai ser testado
            int idade = 18;
            bool resultadoEsperado = true;
            var pessoa = new PessoaFisica();
            //executar o programa
            var resultado = pessoa.VerificarMaioridade(idade);



            //validar o teste
            Assert.True(resultado == resultadoEsperado);

        }
    }
}
