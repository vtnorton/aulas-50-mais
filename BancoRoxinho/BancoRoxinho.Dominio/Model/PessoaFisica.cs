using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaFisica : Pessoa
    {
        public int Idade { get; set; }
        public string CPF { get; set; }

        public string Nome { private get; set; }
        public string Sobrenome { private get; set; }

        public string NomeCompleto
        {
            get
            {
                //VitorNorton
                //Vitor Norton
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

        public bool VerificarMaioridade(int idade)
        {
            return MaiorIdade;
        }

        public PessoaFisica CadastrarPessoa()
        {
            var pessoa = new PessoaFisica();

            Console.WriteLine("Digite o nome da pessoa: ");
            string nomeRecebido = Console.ReadLine();
            pessoa.Nome = nomeRecebido;

            Console.WriteLine("Digite o sobrenome da pessoa: ");
            string sobrenomeRecebido = Console.ReadLine();
            pessoa.Sobrenome = sobrenomeRecebido;

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