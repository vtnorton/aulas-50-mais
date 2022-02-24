using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using System;

namespace BancoRoxinho.Dominio
{
    internal class Program
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                bool continuarNoPrograma = true;
                do
                {
                    Console.WriteLine("Bem vindo ao banco Roxinho");
                    Console.WriteLine("Escolha um número para prosseguir:");
                    Console.WriteLine("1 - Cadastrar pessoa física");
                    Console.WriteLine("2 - Ler pessoas físicas cadastrada");
                    Console.WriteLine("3 - Cadastrar pessoa Jurídica");
                    Console.WriteLine("4 - Ler pessoas Juridicas cadastrada");
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
                            EscolheuAOpcaoCadastrarPessoaJuridica();
                            break;

                        case 4:
                            EscolheuAOpcaoDeVerPessoasJuridica();
                            break;

                        case 0:
                        default:
                            continuarNoPrograma = false;
                            break;
                    }
                } while (continuarNoPrograma);
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

                PessoasRepository.PessoasJuridicas.Add(pessoaJuridicaCadastrada);
            }

            static void EscolheuAOpcaoDeVerPessoasJuridica()
            {
                var listaPessoaJuridica = PessoasRepository.PessoasJuridicas;
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
