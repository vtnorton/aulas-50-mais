using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaFisica : Pessoa
    {

        public int Idade { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string NomeCompleto
        {
            get
            {
                return Nome + " " + Sobrenome;
            }
        }

        public bool MaiorIdade
        {
            get
            {
                if (Idade >= 18)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        bool VerificarCPF(string cpfASerValdido)
        {
            var verificador = new Main();
            var cpfValido = verificador.IsValidCPFCNPJ(cpfASerValdido);
            return cpfValido;
        }

        public PessoaFisica CadastrarPessoa()
        {
            var pessoa = new PessoaFisica();

            Console.WriteLine("Digite o nome da pessoa: ");
            Nome = Console.ReadLine();
            pessoa.Nome = Nome;

            Console.WriteLine("Digite o sobrenome da pessoa: ");
            Sobrenome = Console.ReadLine();
            pessoa.Sobrenome = Sobrenome;

            Console.WriteLine("Digite o CPF de " + pessoa.NomeCompleto + ":");
            pessoa.CPF = Console.ReadLine();

            bool cpfValido = VerificarCPF(pessoa.CPF);
            if (!cpfValido)
            {
                Console.WriteLine("CPF inválido.");
                return null;
            }

            Console.WriteLine("Digite a idade da pessoa");
            pessoa.Idade = int.Parse(Console.ReadLine());

            if (!pessoa.MaiorIdade)
            {
                Console.WriteLine("Idade inválida.");
                return null;
            }

            Console.Clear();

            return pessoa;
        }
    }
}
