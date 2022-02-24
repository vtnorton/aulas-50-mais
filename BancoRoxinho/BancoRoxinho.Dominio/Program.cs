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
            Console.WriteLine("3 - Cadastrar pessoa Jurídica");
            Console.WriteLine("4 - Ler pessoas Juridicas cadastrada");

            int escolhaDoUsuario = int.Parse(Console.ReadLine());

           
            switch(escolhaDoUsuario)
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

        static void EscolheuAOpcaoCadastrarPessoaJuridica()
        {
            var pessoaJuridica = new PessoaJuridica();
            var pessoaCadastrada = pessoaJuridica.CadastrarPessoaJuridica();

            PessoasRepository.PessoaJuridicas.Add(pessoaCadastrada);
        }
    }
}