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
        PessoaJuridica pessoa = new PessoaJuridica();

        string cnpj = "93421891000130";
        [Fact]
        public void DeveValidarCnpjOk()
        {
            var resultadoEsperado = true;
            var retorno = pessoa.VerificarCNPJ(cnpj);

            Assert.True(resultadoEsperado == retorno);



        }
        [Fact]
        public void DeveValidarCnpjNok()
        {
            var cnpj = "93421891000131";
            var resultadoEsperado = false;
            var retorno = pessoa.VerificarCNPJ(cnpj);

            Assert.True(resultadoEsperado == retorno);



        }




    }
}
