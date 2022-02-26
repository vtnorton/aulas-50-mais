using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using System;

namespace BancoRoxinho.Dominio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuarNoPrograma = true;


            Console.WriteLine("Bem vindo ao banco Roxinho");
            Console.WriteLine("Escolha um número para prosseguir:");
            Console.WriteLine("F - Cadastrar pessoa física");
            Console.WriteLine("J - Cadastrar pessoa Jurídica");


            string escolha = Console.ReadLine();
            do
            {
                if (escolha == "F")
                {
                    Console.WriteLine("Pessoa Fisica:");
                    Console.WriteLine("1 - Cadastrar pessoa física");
                    Console.WriteLine("2 - Ler pessoas físicas cadastrada");
                    Console.WriteLine("3 - Editar pessoa física");
                    Console.WriteLine("4 - Excluir pessoa física");
                    Console.WriteLine("0 - Sair");


                    int escolhaDoUsuario = int.Parse(Console.ReadLine());
                    switch (escolhaDoUsuario)
                    {
                        case 1:
                            EscolheuAOpcaoCadastrarPessoa();
                            break;

                        case 2:
                            EscolheuAOpcaoDeVerPessoasFisicas();
                            break;
                        case 3:
                            EscolheuAOpcaoEditarUmaPessoaFisica();
                            break;
                        case 4:
                            EscolheuAOpcaoDeExcluirPessoaFisica();
                            break;
                        case 0:
                        default:
                            continuarNoPrograma = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pessoa Juridica:");
                    Console.WriteLine("1 - Cadastrar pessoa Juridica");
                    Console.WriteLine("2 - Ler pessoa Juridica");
                    Console.WriteLine("3 - Editar pessoa Juridica");
                    Console.WriteLine("4 - Excluir pessoa Juridica");
                    Console.WriteLine("0 - Sair");

                    int escolhaDoUsuario = int.Parse(Console.ReadLine());

                    switch (escolhaDoUsuario)
                    {
                        case 1:
                            EscolheuAOpcaoCadastrarPessoaJuridica();

                            break;

                        case 2:
                            EscolheuAOpcaoDeVerPessoasJuridica();
                            break;

                        case 3:


                            break;

                        case 4:

                            break;

                        case 0:
                        default:
                            continuarNoPrograma = false;
                            break;
                    }
                }
            } while (continuarNoPrograma);







                static void EscolheuAOpcaoEditarUmaPessoaFisica()
                {

                }

                static void EscolheuAOpcaoDeExcluirPessoaFisica()
                {

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
                    var pessoa = new PessoaFisica();

                    listaPessoas.ForEach(pessoa =>
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Pessoa de Nº ");
                        Console.WriteLine("Nome da pessoa: " + pessoa.Nome);
                        Console.WriteLine("Idade da pessoa: " + pessoa.Idade);
                        Console.WriteLine("Conta da pessoa: " + pessoa.ContaCorrente.NumeroDaConta);
                        Console.WriteLine("");
                    });
                }

                static void EscolheuAOpcaoCadastrarPessoaJuridica()
                {
                    var pessoaJuridica = new PessoaJuridica();
                    var pessoaJuridicaCadastrada = pessoaJuridica.CadastrarPessoaJuridica();

                    PessoasRepository.PessoaJuridicas.Add(pessoaJuridicaCadastrada);
                }

                static void EscolheuAOpcaoDeVerPessoasJuridica()
                {
                    var listaPessoaJuridica = PessoasRepository.PessoaJuridicas;
                    var Juridica = new PessoaJuridica();

                    listaPessoaJuridica.ForEach(Juridica =>
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Nome da pessoa: " + Juridica.Nome);
                        Console.WriteLine("CNPJ da Empresa: " + Juridica.CNPJ);
                        Console.WriteLine("");
                    });
                }

                   
        }
    }
}


