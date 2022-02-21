using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa

    public class PessoaJuridica : Pessoa
    {

        public string CNPJ = "00.000.000/0000-00";
        public string Nome;

        bool VerificarCNPJ(string cnpjASerValdido)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValdido);
            return cnpjValido;
        }

        public PessoaJuridica CadastrarPessoaj()
        {
            var pessoa = new PessoaJuridica();
            Console.WriteLine("Digite o nome da pessoa Juridica: ");
            pessoa.Nome = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ de " + pessoa.Nome + ":");
            pessoa.CNPJ = Console.ReadLine();

            bool cnpjValido = VerificarCNPJ(pessoa.CNPJ);
            if (!cnpjValido)
            {
                Console.WriteLine("CNPJ inválido.");
                return null;
            }
            Console.Clear();
            return pessoa;
        }
    }
}
