using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaFisica : Pessoa
    {
        public int Idade;
        public string CPF = "000.000.000-00";
        public string Nome;

        bool VerificarCPF(string cpfASerValdido)
        {
            var verificador = new Main();
            var cpfValido = verificador.IsValidCPFCNPJ(cpfASerValdido);
            return cpfValido;
        }

        public bool VerificarMaioridade(int idade)
        {
            if (idade >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public PessoaFisica CadastrarPessoa()
        {
            var pessoa = new PessoaFisica();
            Console.WriteLine("Digite o nome da pessoa: ");
            pessoa.Nome = Console.ReadLine();

            Console.WriteLine("Digite o CPF de " + pessoa.Nome + ":");
            pessoa.CPF = Console.ReadLine();

            bool cpfValido = VerificarCPF(pessoa.CPF);
            if (!cpfValido)
            {
                Console.WriteLine("CPF inválido.");
                return null;
            }
            
            Console.WriteLine("Digite a idade da pessoa");
            pessoa.Idade = int.Parse(Console.ReadLine());
            bool idadeValida = VerificarMaioridade(pessoa.Idade);
            if (!idadeValida)
            {
                Console.WriteLine("Idade inválida.");
                return null;
            }
            Console.Clear();

            return pessoa;
        } 
    }
}
