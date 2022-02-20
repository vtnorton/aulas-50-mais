using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {
        public string RazaoSocial;
        public string CNPJ = "00.000.000/0000-00";

        bool VerificarCNPJ (string cnpjASerValidado)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValidado);
            return cnpjValido;
        }
        public PessoaJuridica CadastrarPessoa()            
        {
            var pessoa = new PessoaJuridica();
            Console.WriteLine("Digite a Razão Social: ");
            pessoa.RazaoSocial = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ: ");
            pessoa.CNPJ = Console.ReadLine();

            bool cnpjValido = VerificarCNPJ(pessoa.CNPJ);
            {
                if (!cnpjValido)
                {
                    Console.WriteLine("CNPJ inválido.");
                    return null;
                }
            }

            Console.Clear();
            return pessoa;

        }
    }
}
