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
    }
}
