using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{

    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ = "00.000.000/0000-00";
        public string RazaoSocial ;

        public bool VerificarCPF(string cnpjASerValdido)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValdido); 
            return cnpjValido;
        }
        public PessoaJuridica CadastrarPessoaJuridica()
        {

            var pessoaJuridica = new PessoaJuridica();
            Console.WriteLine("Digite a Razão Social da empresa");
            pessoaJuridica.RazaoSocial = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ de " + pessoaJuridica.RazaoSocial + ";");
            pessoaJuridica.CNPJ = Console.ReadLine();

            if (!VerificarCPF(pessoaJuridica.CNPJ))
            {
                Console.WriteLine("CNPJ inválido!");
                return null;
            }

            return pessoaJuridica;
        }
    }
}
