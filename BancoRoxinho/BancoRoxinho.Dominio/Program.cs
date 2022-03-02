using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using BancoRoxinho.Dominio.Services;
using System;
using System.Collections.Generic;

namespace BancoRoxinho.Dominio
{
    internal class Program
    {
        private static PessoaFisicaService pessoaFisicaService = new PessoaFisicaService();
        private static PessoaJuridicaService pessoaJuridicaService = new PessoaJuridicaService();

        static void Main(string[] args)
        {
            bool continuarNoPrograma = true;

            int escolha;
            int permanecer;

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("====== BEM VINDO AO BANCO ROXINHO ======");
                Console.WriteLine(" Escolha uma opção para prosseguir:");
                Console.WriteLine(" 1 - Pessoa física");
                Console.WriteLine(" 2 - Pessoa Jurídica");

                bool issNumeric = int.TryParse(Console.ReadLine(), out escolha);


                if (!issNumeric)
                    Console.WriteLine("====== SOMENTE NÚMEROS SÃO ACEITOS =======");

                if (escolha == 1)
                {
                    MenuPessoaFisica();

                    int escolhaDoUsuario;
                    bool isNumeric = int.TryParse(Console.ReadLine(), out escolhaDoUsuario);

                    if (!isNumeric)
                        Console.WriteLine("====== SOMENTE NÚMEROS SÃO ACEITOS =======");
                    else
                    {
                        switch (escolhaDoUsuario)
                        {
                            case 0:
                                Console.WriteLine("====== VOCÊ ESCOLHEU SAIR =======");
                                continuarNoPrograma = false;
                                break;

                            case 1:

                                EscolheuAOpcaoCadastrarPessoa();
                                permanecer = 1;

                                while (permanecer == 1)
                                {
                                    Console.WriteLine("\n" + "====== VOCÊ DESEJA CONTINUAR =======");
                                    Console.WriteLine("====== [1] Sim [2] Não =======");
                                    permanecer = int.Parse(Console.ReadLine());
                                    if (permanecer == 1)
                                    {
                                        EscolheuAOpcaoCadastrarPessoa();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                    }
                                }

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
                            default:
                                Console.WriteLine("====== OPÇÃO INVÁLIDA =======");

                                break;
                        }
                    }
                }

                if (escolha == 2)
                {
                    MenuPessoaJuridica();

                    int escolhaDoUsuario;
                    bool isNumeric = int.TryParse(Console.ReadLine(), out escolhaDoUsuario);

                    if (!isNumeric)
                        Console.WriteLine("====== SOMENTE NÚMEROS SÃO ACEITOS =======");
                    else
                    {
                        switch (escolhaDoUsuario)
                        {
                            case 0:
                                Console.WriteLine("====== VOCÊ ESCOLHEU SAIR =======");
                                continuarNoPrograma = false;
                                break;

                            case 1:
                                EscolheuAOpcaoCadastrarPessoaJuridica();

                                permanecer = 1;

                                while (permanecer == 1)
                                {
                                    Console.WriteLine("\n" + "====== VOCÊ DESEJA CONTINUAR =======");
                                    Console.WriteLine("====== [1] Sim [2] Não =======");
                                    permanecer = int.Parse(Console.ReadLine());
                                    if (permanecer == 1)
                                    {
                                        EscolheuAOpcaoCadastrarPessoaJuridica();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                    }
                                }

                                break;

                            case 2:

                                EscolheuAOpcaoDeVerPessoasJuridica();

                                break;
                            case 3:

                                EscolheuAOpcaoEditarUmaPessoaJuridica();

                                break;

                            case 4:

                                EscolheuAOpcaoDeExcluirPessoaJuridica();

                                break;


                            default:
                                Console.WriteLine("====== OPÇÃO INVÁLIDA =======");
                                break;
                        }
                    }
                }

            } while (continuarNoPrograma);


        }


        static void EscolheuAOpcaoCadastrarPessoa()
        {

            PessoaFisica pessoa = new PessoaFisica();

            Console.WriteLine("Digite o nome da pessoa: ");
            pessoa.Nome = Console.ReadLine();

            Console.WriteLine("Digite o seu sobrenome: ");
            pessoa.Sobrenome = Console.ReadLine();

            Console.WriteLine("Digite apenas números");
            Console.WriteLine("do seu CPF: ");
            pessoa.CPF = Console.ReadLine();

            Console.WriteLine("Digite a sua idade: ");
            pessoa.Idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o seu endereço: ");
            pessoa.Endereco = Console.ReadLine();

            pessoaFisicaService.Adicionar(pessoa.Nome, pessoa.Sobrenome, pessoa.Idade, pessoa.CPF, pessoa.Endereco);

        }


        static void EscolheuAOpcaoDeVerPessoasFisicas()
        {


            Console.WriteLine("==== EXIBINDO PESSOAS FÍSICAS CADASTRADAS ====");
            List<PessoaFisica> listaDePessoas = PessoasRepository.PessoasFisicas;

            foreach (PessoaFisica pessoa in listaDePessoas)
            {
                Console.WriteLine("\n" + pessoa.NomeCompleto);
                Console.WriteLine("Numero CPF: " + pessoa.CPF);
                Console.WriteLine("Nº da Conta: " + pessoa.ContaCorrente.NumeroDaConta);
                if (!string.IsNullOrEmpty(pessoa.Endereco))
                {
                    Console.WriteLine("Endereço: " + pessoa.Endereco);
                }
                Console.WriteLine("Idade: " + pessoa.Idade);
            }
        }

        static void EscolheuAOpcaoEditarUmaPessoaFisica()
        {
            Console.WriteLine("Digite o seu CPF: ");
            string cpf = Console.ReadLine();

            var pessoaEditada = pessoaFisicaService.ObterPessoa(cpf);

            Console.WriteLine("Pressione ENTER para pular uma etapa.");
            Console.WriteLine("Digite o nome da pessoa: (Nome atual: " + pessoaEditada.Nome + ")");
            pessoaEditada.Nome = Console.ReadLine();

            Console.WriteLine("Digite o seu sobrenome: (Sobrenome atual: " + pessoaEditada.Sobrenome + ")");
            pessoaEditada.Sobrenome = Console.ReadLine();

            Console.WriteLine("Digite a sua idade:  (Idade atual: " + pessoaEditada.Idade + ")");
            pessoaEditada.Idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o seu endereço:  (Endereço atual: " + pessoaEditada.Endereco + ")");
            pessoaEditada.Endereco = Console.ReadLine();

            pessoaFisicaService.Editar(
                pessoaEditada.CPF,
                pessoaEditada.Nome,
                pessoaEditada.Sobrenome,
                pessoaEditada.Idade,
                pessoaEditada.Endereco);
        }

        static void EscolheuAOpcaoDeExcluirPessoaFisica()
        {
            Console.WriteLine("Digite o cpf da pessoa a ser excluida: ");
            string cpf = Console.ReadLine();

            pessoaFisicaService.Excluir(cpf);
        }


        static void EscolheuAOpcaoCadastrarPessoaJuridica()
        {

            PessoaJuridica pessoaJuridica = new PessoaJuridica();

            Console.WriteLine("Digite o nome da empresa: ");
            pessoaJuridica.Nome = Console.ReadLine();

            Console.WriteLine("Digite o nome Fantasia: ");
            pessoaJuridica.NomeFantasia = Console.ReadLine();

            Console.WriteLine("Digite apenas números");
            Console.WriteLine("do seu CNPJ: ");
            pessoaJuridica.CNPJ = Console.ReadLine();

            Console.WriteLine("Digite o seu endereço: ");
            pessoaJuridica.Endereco = Console.ReadLine();

            pessoaJuridicaService.Adicionar(pessoaJuridica.Nome, pessoaJuridica.NomeFantasia, pessoaJuridica.CNPJ, pessoaJuridica.Endereco);

        }

        static void EscolheuAOpcaoDeVerPessoasJuridica()
        {

            Console.WriteLine("==== EXIBINDO PESSOAS JURIDICAS CADASTRADAS ====");
            List<PessoaJuridica> listaDePessoas = PessoasRepository.PessoaJuridicas;

            foreach (PessoaJuridica pessoaJuridica in listaDePessoas)
            {
                Console.WriteLine("\n" + "Nome: " + pessoaJuridica.Nome);
                Console.WriteLine("Nome Fantasia: " + pessoaJuridica.NomeFantasia);
                Console.WriteLine("Numero CNPJ: " + pessoaJuridica.CNPJ);
                Console.WriteLine("Nº da Conta: " + pessoaJuridica.ContaCorrente.NumeroDaConta);
                if (!string.IsNullOrEmpty(pessoaJuridica.Endereco))
                {
                    Console.WriteLine("Endereço: " + pessoaJuridica.Endereco);
                }
            }

        }

        static void EscolheuAOpcaoEditarUmaPessoaJuridica()
        {
            Console.WriteLine("Digite o seu CNPJ: ");
            string cnpj = Console.ReadLine();

            var empresaEditada = pessoaJuridicaService.ObterEmpresa(cnpj);

            Console.WriteLine("Pressione ENTER para pular uma etapa.");
            Console.WriteLine("Digite o nome da Empresa: (Nome atual: " + empresaEditada.Nome + ")");
            empresaEditada.Nome = Console.ReadLine();

            Console.WriteLine("Digite o nome Fantasia: (Nome Fantasia atual: " + empresaEditada.NomeFantasia + ")");
            empresaEditada.NomeFantasia = Console.ReadLine();

            Console.WriteLine("Digite o seu endereço:  (Endereço atual: " + empresaEditada.Endereco + ")");
            empresaEditada.Endereco = Console.ReadLine();

            pessoaJuridicaService.Editar(
                empresaEditada.CNPJ,
                empresaEditada.Nome,
                empresaEditada.NomeFantasia,
                empresaEditada.Endereco);
        }

        static void EscolheuAOpcaoDeExcluirPessoaJuridica()
        {
            Console.WriteLine("Digite o cnpj da empresa a ser excluida: ");
            string cnpj = Console.ReadLine();

            pessoaJuridicaService.Excluir(cnpj);
        }


        static void MenuPessoaFisica()
        {
            Console.WriteLine("\n");
            Console.WriteLine("====== PESSOA FÍSICA =======");
            Console.WriteLine("1 - Cadastrar pessoa física");
            Console.WriteLine("2 - Ler pessoas físicas cadastrada");
            Console.WriteLine("3 - Editar pessoa física");
            Console.WriteLine("4 - Excluir pessoa física");
            Console.WriteLine("0 - Sair");
        }

        static void MenuPessoaJuridica()
        {
            Console.WriteLine("\n");
            Console.WriteLine("====== PESSOA JURÍDICA ======");
            Console.WriteLine("1 - Cadastrar pessoa Juridica");
            Console.WriteLine("2 - Ler pessoa JurÍdica");
            Console.WriteLine("3 - Editar pessoa JurÍdica");
            Console.WriteLine("4 - Excluir pessoa JurÍdica");
            Console.WriteLine("0 - Sair");
        }
    }

}







