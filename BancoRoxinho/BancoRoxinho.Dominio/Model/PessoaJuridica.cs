using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ = "55645180000150";
        public string RazaoSocial = "";

        bool VerificarCNPJ(string cnpjASerValidado)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValidado);
            return cnpjValido;
        }
        public PessoaJuridica CadastrarPessoaJuridica()
        {
            var pessoaJuridica = new PessoaJuridica();
            Console.WriteLine("Digite o nome da empresa: ");
            pessoaJuridica.RazaoSocial = Console.ReadLine();
            Console.WriteLine("Digite o CNPJ da empresa: ");
            pessoaJuridica.CNPJ = Console.ReadLine();

            bool cnpjValido = VerificarCNPJ(pessoaJuridica.CNPJ);
            if (!cnpjValido)
            {
                Console.WriteLine("CNPJ inválido.");
                return null;
            }
            return pessoaJuridica;

        }
    }
}
