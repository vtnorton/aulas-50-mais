using BancoRoxinho.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BancoRoxinho.Dominio.Test
{
    
    public class PessoaJuridicaTest
    {
        [Fact]
        public void DeveValidarNumeroCnpj()
        {
            string CNPJ = "55645180000150";
            bool cnpjValidacaoEsperado = true;
            var pessoa = new PessoaJuridica();

            var resultado = pessoa.VerificarCNPJ(CNPJ);
            Assert.True(resultado == cnpjValidacaoEsperado);

        }
    }
}
