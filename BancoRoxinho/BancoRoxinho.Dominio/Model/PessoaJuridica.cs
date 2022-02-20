using System;
using BancoRoxinho.Dominio.Dados;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ = "000.000.000/0000-00";
        public string Nome;

        bool VerificarCPF(string cpfASerValdido)
        {
            var verificador = new Main();
            return verificador.IsValidCPFCNPJ(cpfASerValdido);
        }

        public PessoaJuridica CadastrarPessoaJuridica()
        {
            var pessoa = new PessoaJuridica();

            Console.Write("Digite o CNPJ para validação: ");
            pessoa.CNPJ = Console.ReadLine();

            bool cnpjValido = VerificarCPF(pessoa.CNPJ);
            if (!cnpjValido)
            {
                Mensagem.MostrarMensagem("CNPJ inválido, tente novamente. Tecle <ENTER> para continuar.");
                return null;
            }

            Console.Write("Digite o nome da empresa: ");
            pessoa.Nome = Console.ReadLine();

            Console.Write("Digite a conta do corrente: ");
            pessoa.ContaCorrente.NumeroDaConta = int.Parse(Console.ReadLine());

            Mensagem.MostrarMensagem("Inclusão feita na base do Banco Roxinho. Tecle <ENTER> para continuar.");

            PessoasRepository.PessoasJuridicas.Add(pessoa);
            return null;
        }

        public PessoaJuridica VisualizarPessoaJuridica()
        {
            var listaPessoas = PessoasRepository.PessoasJuridicas;

            for (int i = 0; i <= listaPessoas.Count - 1; i++)
            {
                var pessoa = listaPessoas[i];
                Console.WriteLine(Mensagem.pontilhados);
                Console.WriteLine("Pessoa de Nº " + (i + 1));
                Console.WriteLine("Nome :.............. " + pessoa.Nome);
                Console.WriteLine("Conta Corrente :.... " + pessoa.ContaCorrente.NumeroDaConta);
                Console.WriteLine("CPF :............... " + pessoa.CNPJ);
                Console.WriteLine(Mensagem.pontilhados);
            }
            Console.Read();
            return null;
        }

    }



}
