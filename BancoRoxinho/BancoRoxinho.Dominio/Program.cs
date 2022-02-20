using BancoRoxinho.Dominio.Model;
using System;

namespace BancoRoxinho.Dominio
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(Mensagem.pontilhados);
                Console.WriteLine("Bem vindo ao Banco Roxinho");
                Console.WriteLine(Mensagem.pontilhados);
                Console.WriteLine("Escolha um númnero para prosseguir:");
                Console.WriteLine(Mensagem.pontilhados);
                Console.WriteLine("0 -  Para sair");
                Console.WriteLine(Mensagem.pontilhados);
                Console.WriteLine("1 -  Cadastrar pessoa física");
                Console.WriteLine("2 -  Ler pessoas físicas cadastradas");
                Console.WriteLine(Mensagem.pontilhados);
                Console.WriteLine("3 -  Cadastrar pessoa jurídica");
                Console.WriteLine("4 -  Ler pessoas jurídicas cadastradas");
                Console.WriteLine(Mensagem.pontilhados);

                String escolhaDoUsuario = Console.ReadLine();
                if (escolhaDoUsuario != null && escolhaDoUsuario != string.Empty)
                {
                    int escolha = int.Parse(escolhaDoUsuario);
                    if (escolha == 0)
                        break;
                    if (escolha == 1)
                    {
                        Console.Clear();
                        EscolheuOpcaoCadastrarPessoaFisica();
                    }
                    if (escolha == 2)
                    {
                        Console.Clear();
                        EscolheuOpcaoDeVerPessoasFisicas();
                    }
                    if (escolha == 3)
                    {
                        Console.Clear();
                        EscolheuOpcaoCadastrarPessoaJuridica();
                    }
                    if (escolha == 4)
                    {
                        Console.Clear();
                        EscolheuOpcaoDeVerPessoasJuridicas();
                    }
                }
                Console.Clear();
            }
        }

        static void EscolheuOpcaoCadastrarPessoaFisica()
        {
            PessoaFisica pessoaFisica = new PessoaFisica();
            pessoaFisica = pessoaFisica.CadastrarPessoaFisica();
        }

        static void EscolheuOpcaoDeVerPessoasFisicas()
        {
            PessoaFisica pessoaFisica = new PessoaFisica();
            pessoaFisica = pessoaFisica.VisualizarPessoaFisica();
        }

        static void EscolheuOpcaoCadastrarPessoaJuridica()
        {
            PessoaJuridica pessoaJuridica = new PessoaJuridica();
            pessoaJuridica = pessoaJuridica.CadastrarPessoaJuridica();

        }
        static void EscolheuOpcaoDeVerPessoasJuridicas()
        {
            PessoaJuridica pessoaJuridica = new PessoaJuridica();
            pessoaJuridica = pessoaJuridica.VisualizarPessoaJuridica();

        }

    }
}
