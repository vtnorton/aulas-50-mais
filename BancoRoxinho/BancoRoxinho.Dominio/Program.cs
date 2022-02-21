using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using System;

namespace BancoRoxinho.Dominio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao banco Roxinho");
            Console.WriteLine("Escolha um número para prosseguir:");
            Console.WriteLine("1 - Cadastrar pessoa física");
            Console.WriteLine("2 - Ler pessoas físicas cadastrada");
            Console.WriteLine("3 - Cadastrar pessoa Juridica");

            int escolhaDoUsuario = int.Parse(Console.ReadLine());
            if(escolhaDoUsuario == 1)
            {
                EscolheuAOpcaoCadastrarPessoa();
            }

            if(escolhaDoUsuario == 2)
            {
                EscolheuAOpcaoDeVerPessoasFisicas();
            }

            if (escolhaDoUsuario == 3)
            {
                EscolheuAOpcaoCadastrarPessoaJuridica();
            }
            Console.Read();
        }

        static void EscolheuAOpcaoDeVerPessoasFisicas()
        {
            var listaPessoas = PessoasRepository.PessoasFisicas;

            // Explicar melhor na próxima aula
            for (int contador = 0; contador <= listaPessoas.Count; contador++)
            {
                // Explicar melhor na próxima aula
                var pessoa = listaPessoas[contador];
                Console.WriteLine("");
                Console.WriteLine("Pessoa de Nº " + contador);
                Console.WriteLine("Nome da pessoa: " + pessoa.Nome);
                Console.WriteLine("Idade da pessoa: " + pessoa.Idade);
                Console.WriteLine("Conta da pessoa: " + pessoa.ContaCorrente.NumeroDaConta);
                Console.WriteLine("");
            }
        }

        static void EscolheuAOpcaoCadastrarPessoa()
        {
            var pessoa = new PessoaFisica();
            var pessoaCadastrada = pessoa.CadastrarPessoa();

            PessoasRepository.PessoasFisicas.Add(pessoaCadastrada);

        }

        static void EscolheuAOpcaoDeVerPessoasFisicas()
        {
            var listaPessoas = PessoasRepository.PessoasFisicas;

            // Explicar melhor na próxima aula
            for (int contador = 0; contador <= listaPessoas.Count; contador++)
            {
                // Explicar melhor na próxima aula
                var pessoa = listaPessoas[contador];
                Console.WriteLine("");
                Console.WriteLine("Pessoa de Nº " + contador);
                Console.WriteLine("Nome da pessoa: " + pessoa.Nome);
                Console.WriteLine("Idade da pessoa: " + pessoa.Idade);
                Console.WriteLine("Conta da pessoa: " + pessoa.ContaCorrente.NumeroDaConta);
                Console.WriteLine("");
            }
        }

        static void EscolheuAOpcaoCadastrarPessoa()
        {
            var pessoa = new PessoaFisica();
            var pessoaCadastrada = pessoa.CadastrarPessoa();

            PessoasRepository.PessoasFisicas.Add(pessoaCadastrada);
        
        }

        static void EscolheuAOpcaoCadastrarPessoaJuridica()
        {
            var pessoa = new PessoaJuridica();
            var pessoaCadastrada = pessoa.CadastrarPessoaj();

            PessoasRepository.PessoaJuridicas.Add(pessoaCadastrada);

        }


    }
}
