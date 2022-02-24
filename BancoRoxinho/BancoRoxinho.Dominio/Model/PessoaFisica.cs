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
        
        private bool _maiorIdade;

        public bool MaiorIdade
        {
            get {
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

        public void SetNome(string nomeASerDefinido)
        {
            _nome = nomeASerDefinido;
        }

        public void SetSobreNome(string sobrenomeASerDefinido)
        {
            _sobrenome = sobrenomeASerDefinido;
        }

        public string GetNomeCompleto()
        {
            return _nome + "" + _sobrenome;
        } 


        public bool GetMaiorIdade()
        {
            return _maiorIdade;
        }

        bool VerificarCPF(string cpfASerValidado)
        {
            var verificador = new Main();
            var cpfValido = verificador.IsValidCPFCNPJ(cpfASerValidado);
            return cpfValido;
        }

        public PessoaFisica CadastrarPessoa()
        {
            var pessoa = new PessoaFisica();
            Console.WriteLine("Digite o nome da pessoa: ");
            String nomeRecebido = Console.ReadLine();
            SetNome(nomeRecebido);

            Console.WriteLine("Digite o sobrenome da pessoa: ");
            String sobrenomeRecebido = Console.ReadLine();
            SetSobreNome(nomeRecebido);


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
