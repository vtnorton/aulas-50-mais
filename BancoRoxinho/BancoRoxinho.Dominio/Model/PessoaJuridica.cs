using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    // Herança PessoaJuridica : Pessoa, ou seja PessoaJuridica esta herdando Pessoa
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ = "00000000000000";
        public string Nome;

        bool VerificarCNPJ()
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(CNPJ);
            return cnpjValido;
        }

       
        public PessoaJuridica CadastrarPessoa()
        {
            throw new NotImplementedException();
        }
        
    }
}
