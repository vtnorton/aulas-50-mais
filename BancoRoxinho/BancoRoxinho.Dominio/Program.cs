using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using System;

namespace BancoRoxinho.Dominio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // do while
            // faça enquanto
            bool continuarNoPrograma = true;
            do
            {
                Console.WriteLine("Bem vindo ao banco Roxinho");
                Console.WriteLine("Escolha um número para prosseguir:");
                Console.WriteLine("1 - Cadastrar pessoa física");
                Console.WriteLine("2 - Ler pessoas físicas cadastrada");
                Console.WriteLine("3 - Cadastrar pessoas juridicas ");
                Console.WriteLine("4 - Ler pessoas juridicas cadastradas ");
                Console.WriteLine("0 - Sair");

                int escolhaDoUsuario = int.Parse(Console.ReadLine());

                // switch case
                // mudar  caso

                switch (escolhaDoUsuario)
                {
                    case 1:
                        EscolheuAOpcaoCadastrarPessoa();
                        break;
                    case 2:
                        EscolheuAOpcaoDeVerPessoasFisicas();
                        break;
                    case 3:
                        EscolheuAOpcaoCadastrarPessoaJuridica();
                        break;
                    case 4:
                        EscolheuAOpcaoDeVerPessoasJuridicas();
                        break;
                    case 0:
                    default: //padrão
                        continuarNoPrograma = false;
                        break;
                }

            } while (continuarNoPrograma);
        }

        static void EscolheuAOpcaoDeVerPessoasFisicas()
        {
            var listaPessoas = PessoasRepository.PessoasFisicas;

            /* 
                foreach (var pessoa in listaPessoas)
                {

                }
            */

            listaPessoas.ForEach(pessoa =>
            {
                Console.WriteLine("");
                // Mostrar na aula de arrays/listas
                Console.WriteLine("Pessoa de Nº ");
                Console.WriteLine("Nome da pessoa: " + pessoa.Nome);
                Console.WriteLine("Idade da pessoa: " + pessoa.Idade);
                Console.WriteLine("Conta da pessoa: " + pessoa.ContaCorrente.NumeroDaConta);
                Console.WriteLine("");
            });
        }

        static void EscolheuAOpcaoCadastrarPessoa()
        {
            var pessoa = new PessoaFisica();
            var pessoaCadastrada = pessoa.CadastrarPessoa();

            PessoasRepository.PessoasFisicas.Add(pessoaCadastrada);
        }
        private static void EscolheuAOpcaoDeVerPessoasJuridicas()
        {

            var listaPessoasJuridicas = PessoasRepository.PessoaJuridicas;

            for (int contador = 0; contador < listaPessoasJuridicas.Count; contador++)
            {

                var pessoaJuridica = listaPessoasJuridicas[contador];
                Console.WriteLine("");
                Console.WriteLine("Empresa de Nº " + contador);
                Console.WriteLine("Nome da empresa: " + pessoaJuridica.Razao);
                Console.WriteLine("CNPJ da pessoa: " + pessoaJuridica.CNPJ);

                Console.WriteLine("");
            }
        }
        private static void EscolheuAOpcaoCadastrarPessoaJuridica()
        {
            var pessoaJuridica = new PessoaJuridica();
            var pessoaJuridicaCadastrada = pessoaJuridica.CadastrarPessoaJuridica();

            PessoasRepository.PessoaJuridicas.Add(pessoaJuridicaCadastrada);

        }
    }
}
