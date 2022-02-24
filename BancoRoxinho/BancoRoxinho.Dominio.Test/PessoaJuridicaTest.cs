using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BancoRoxinho.Dominio.Model;

namespace BancoRoxinho.Dominio.Test
{
    public class PessoaJuridicaTest
    {
        [Fact]
        public void DeveValidarCNPJDaEmpresa()
        {
            // definir o que vai ser testado
            var cnpj = "00.000.000/0000-00";
            bool resultadoEsperado = true;
            var pessoaJuridica = new PessoaJuridica();

            //executar o programa
            var resultado = pessoaJuridica.VerificarCNPJ(cnpj);

            // validar o teste
            Assert.True(resultado == resultadoEsperado);
        }

    }
}
