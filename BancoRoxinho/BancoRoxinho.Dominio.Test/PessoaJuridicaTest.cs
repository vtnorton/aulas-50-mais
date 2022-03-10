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
        public void DeveRetornarTrueQuandoCNPJForValido()
        {
            string cnpj = "02.570.336/0001-15";
            bool resultadoEsperado = true;
            PessoaJuridica pessoa = new PessoaJuridica();

            var resultado = pessoa.VerificarCNPJ(cnpj);
            Assert.True(resultado == resultadoEsperado);
        }
    }
}
