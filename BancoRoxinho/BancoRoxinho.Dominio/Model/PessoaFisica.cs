using System;
using BancoRoxinho.Dominio.Dados;
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
            return verificador.IsValidCPFCNPJ(cpfASerValdido);
        }

        bool VerificarMaioridade(int idade)
        {
            return (idade >= 18) ? true : false;
        }

        public PessoaFisica CadastrarPessoaFisica()
        {
            var pessoa = new PessoaFisica();

            Console.Write("Digite o CPF para validação: ");
            pessoa.CPF = Console.ReadLine();

            bool cpfValido = VerificarCPF(pessoa.CPF);
            if (!cpfValido)
            {
                Mensagem.MostrarMensagem("CPF inválido, tente novamente. Tecle <ENTER> para continuar.");
                return null;
            }

            Console.Write("Digite o nome da pessoa: ");
            pessoa.Nome = Console.ReadLine();

            Console.Write("Digite a idade da pessoa: ");
            pessoa.Idade = int.Parse(Console.ReadLine());

            bool idadeValida = VerificarMaioridade(pessoa.Idade);
            if (!idadeValida)
            {
                Mensagem.MostrarMensagem("Idade inválida, deverá ser maior de 18 anos. Tecle <ENTER> para continuar.");
                return null;
            }


            Console.Write("Digite a conta do corrente: ");
            pessoa.ContaCorrente.NumeroDaConta = int.Parse(Console.ReadLine());

            Mensagem.MostrarMensagem("Inclusão feita na base do Banco Roxinho. Tecle <ENTER> para continuar.");

            PessoasRepository.PessoasFisicas.Add(pessoa);
            return null;
        }

        public PessoaFisica VisualizarPessoaFisica()
        {
            var listaPessoas = PessoasRepository.PessoasFisicas;

            for (int i = 0; i <= listaPessoas.Count - 1; i++)
            {
                var pessoa = listaPessoas[i];
                Console.WriteLine(Mensagem.pontilhados);
                Console.WriteLine("Pessoa de Nº " + (i + 1));
                Console.WriteLine("Nome :.............. " + pessoa.Nome);
                Console.WriteLine("Idade :............. " + pessoa.Idade);
                Console.WriteLine("Conta Corrente :.... " + pessoa.ContaCorrente.NumeroDaConta);
                Console.WriteLine("CPF :............... " + pessoa.CPF);
                Console.WriteLine(Mensagem.pontilhados);
            }
            Console.Read();

            return null;
        }

    }
}