using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaFisica : Pessoa
    {
        public int Idade { get; private set; }
        public string CPF { get; set; }
        public string NomeDaMae { get; set; }

        private string _nome;
        private string _sobrenome;

        public bool MaiorIdade {
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

        // setter = definir
        public void SetNome(string nomeASerDefinido)
        {
            _nome = nomeASerDefinido;
        }

        public void SetSobrenome(string sobrenomeASerDefinido)
        {
            _sobrenome = sobrenomeASerDefinido;
        }

        public string GetNomeCompleto()
        {
            return _nome + " " + _sobrenome;
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
            pessoa.SetNome(nomeRecebido);

            Console.WriteLine("Digite o sobrenome da pessoa: ");
            string sobrenomeRecebido = Console.ReadLine();
            pessoa.SetSobrenome(sobrenomeRecebido);

            Console.WriteLine("Digite o CPF de " + pessoa.GetNomeCompleto() + ":");
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
