using CPFCNPJ;
using System;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaJuridica : Pessoa
    {

        public string CNPJ { get; set; }

        public string RazaoSocial { get; set; }


        public bool VerificarCNPJ(string cnpjASerValidado)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValidado);
            return cnpjValido;
        }
    }
}
 