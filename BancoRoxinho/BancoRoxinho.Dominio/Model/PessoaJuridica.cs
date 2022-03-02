using CPFCNPJ;
using System;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ = "";
        public string RazaoSocial;

        public bool VerificarCPF(string cnpjASerValidado)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValidado);
            return cnpjValido;
        }

        public PessoaJuridica CadastrarPessoaJuridica()
        {
            var pessoaJuridica = new PessoaJuridica();
            Console.WriteLine("Digite a Razão Social da Empresa: ");
            pessoaJuridica.RazaoSocial = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ da empresa: " + pessoaJuridica.RazaoSocial);
            pessoaJuridica.CNPJ = Console.ReadLine();

            if (!VerificarCPF(pessoaJuridica.CNPJ))
            {
                Console.WriteLine("CNPJ Inválido.");
                return null;
            }
            return pessoaJuridica;
        }
    }
}
 