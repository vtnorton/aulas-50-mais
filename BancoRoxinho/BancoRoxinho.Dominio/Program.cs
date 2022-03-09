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
            do
            {
                Console.WriteLine("Bem vindo ao banco Roxinho");
                Console.WriteLine();
                Console.WriteLine("************************************************");
                Console.WriteLine("***PESSOA FÍSICA********************************");
                Console.WriteLine("************************************************");
                Console.WriteLine();
                Console.WriteLine("Escolha a OPÇÃO desejada:");
                Console.WriteLine("1 - Cadastrar Pessoa Física");
                Console.WriteLine("2 - Visualizar Pessoas Físicas cadastradas");
                Console.WriteLine("3 - Editar uma Pessoa Física");
                Console.WriteLine("4 - Excluir uma Pessoa Física");
                Console.WriteLine("5 - Exibir uma Pessoa Física");
                Console.WriteLine();
                Console.WriteLine("************************************************");
                Console.WriteLine("***PESSOA JURÍDICA******************************");
                Console.WriteLine("************************************************");
                Console.WriteLine();
                Console.WriteLine("Escolha a OPÇÃO desejada:");
                Console.WriteLine("6 - Cadastrar Pessoa Jurídica");
                Console.WriteLine("7 - Visualizar Pessoas Jurídicas cadastradas");
                Console.WriteLine("8 - Editar Pessoa Jurídica");
                Console.WriteLine("9 - Exibir uma Pessoa Jurídica");
                Console.WriteLine("10 - Excluir Pessoa Jurídica");
                Console.WriteLine();
                Console.WriteLine("0 - Sair");

                int escolhaDoUsuario = int.Parse(Console.ReadLine());
                
                switch (escolhaDoUsuario)
                {
                    case 1:
                        CadastrarPessoaFisica();
                        break;
                    case 2:
                        VisualizaPessoasFisicas();
                        break;
                    case 3:
                        EditarUmaPessoaFisica();
                        break;
                    case 4:
                        ExibirUmaPessoaFisica();
                        break;
                    case 5:
                        ExcluirUmaPessoaFisica();
                        break;
                    case 6:
                        CadastrarPessoaJuridica();
                        break;
                    case 7:
                        VisualizaPessoasJuridicas();
                        break;
                    case 8:
                        EditarUmaPessoaJuridica();
                        break;
                    case 9:
                        ExibirUmaPessoaJuridica();
                        break;
                    case 10:
                        ExcluirUmaPessoaJuridica();
                        break;
                    case 0:
                    default: //padrão
                        continuarNoPrograma = false;
                        break;
                }
                Console.WriteLine("\nDigite OPÇÃO [ 1 ] para Continuar\nDigite OPÇÃO [ 0 ] para SAIR");
                Console.WriteLine("Pressione ENTER");

                int opcao = int.Parse(Console.ReadLine());

                if (opcao == 1) continuarNoPrograma = true;
                else continuarNoPrograma = false;

            } while (continuarNoPrograma);
        }

        static void CadastrarPessoaFisica()
        {
            PessoaFisica pessoa = new PessoaFisica();

            Console.WriteLine("Digite o nome da pessoa: ");
            pessoa.Nome = Console.ReadLine();

            Console.WriteLine("Digite o seu sobrenome: ");
            pessoa.Sobrenome = Console.ReadLine();

            Console.WriteLine("Digite o seu CPF: ");
            pessoa.CPF = Console.ReadLine();

            Console.WriteLine("Digite a sua idade: ");
            pessoa.Idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o seu endereço: ");
            pessoa.Endereco = Console.ReadLine();

            //pessoaFisicaService.Adicionar(pessoa.Nome, pessoa.Sobrenome, pessoa.Idade, pessoa.CPF, pessoa.Endereco);
        }

        static void VisualizaPessoasFisicas()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==== EXIBINDO PESSOAS FÍSICAS CADASTRADAS ====");
            List<PessoaFisica> listaDePessoas = pessoaFisicaService.ObterLista();
            
            foreach(PessoaFisica pessoa in listaDePessoas)
            {
                Console.WriteLine("\n" + pessoa.NomeCompleto);
                Console.WriteLine("Nº da Conta: " + pessoa.ContaCorrente.NumeroDaConta);
                if (!string.IsNullOrEmpty(pessoa.Endereco))
                {
                    Console.WriteLine("Endereço: " + pessoa.Endereco);
                }
                Console.WriteLine("Idade: " + pessoa.Idade);
            }

            Console.ResetColor();
        }

        static void EditarUmaPessoaFisica()
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
        
        static void ExibirUmaPessoaFisica()
        {
            Console.WriteLine("Digite o CPF da pessoa que quer visualizar: ");
            string cpf = Console.ReadLine();

            var pessoa = pessoaFisicaService.ObterPessoa(cpf);

            Console.WriteLine(pessoa.NomeCompleto);
            Console.WriteLine(pessoa.Idade);
            Console.WriteLine(pessoa.Endereco);
        }

        static void ExcluirUmaPessoaFisica()
        {
            Console.WriteLine("Digite o CPF da pessoa a ser excluida: ");
            string cpf = Console.ReadLine();

            pessoaFisicaService.Excluir(cpf);
        }
        //-------------Pessoa Juridica----------------------------------------------------
        static void CadastrarPessoaJuridica()
        {
            PessoaJuridica pessoa = new PessoaJuridica();

            Console.WriteLine("Digite a Razão Social da Empresa: ");
            pessoa.RazaoSocial = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ da Empresa: ");
            pessoa.CNPJ = Console.ReadLine();

            Console.WriteLine("Digite o Endereço da Empresa: ");
            pessoa.Endereco = Console.ReadLine();

            pessoaJuridicaService.Adicionar(pessoa.RazaoSocial, pessoa.CNPJ, pessoa.Endereco);
        }

        static void VisualizaPessoasJuridicas()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==== EXIBINDO PESSOAS JURÍDICAS CADASTRADAS ====");
            List<PessoaJuridica> listaDePessoas = pessoaJuridicaService.ObterLista();

            foreach (PessoaJuridica pessoa in listaDePessoas)
            {
                Console.WriteLine("\n" + pessoa.RazaoSocial);
                Console.WriteLine("CNPJ: " + pessoa.CNPJ);
                Console.WriteLine("Nº da Conta: " + pessoa.ContaCorrente.NumeroDaConta);
                if (!string.IsNullOrEmpty(pessoa.Endereco))
                {
                    Console.WriteLine("Endereco: " + pessoa.Endereco);
                }
            }
            Console.ResetColor();

        }

        static void EditarUmaPessoaJuridica()
        {
            Console.WriteLine("Digite o CNPJ da Empresa: ");
            string cnpj = Console.ReadLine();

            var pessoaJurEditada = pessoaJuridicaService.ObterPessoa(cnpj);

            Console.WriteLine("Pressione ENTER para pular uma etapa.");
            Console.WriteLine("Digite a Razão Social da Empresa: (Nome atual: " + pessoaJurEditada.RazaoSocial + ")");
            pessoaJurEditada.RazaoSocial = Console.ReadLine();

            Console.WriteLine("Digite o seu endereço:  (Endereço atual: " + pessoaJurEditada.Endereco + ")");
            pessoaJurEditada.Endereco = Console.ReadLine();

            pessoaFisicaService.Editar(
                pessoaJurEditada.CNPJ,
                pessoaJurEditada.RazaoSocial,
                pessoaJurEditada.Endereco);
        }

        static void ExibirUmaPessoaJuridica()
        {
            Console.WriteLine("Digite o CNPJ da eMPRESA que quer visualizar: ");
            string cnpj = Console.ReadLine();

            var pessoa = pessoaJuridicaService.ObterPessoa(cnpj);

            Console.WriteLine(pessoa.CNPJ);
            Console.WriteLine(pessoa.RazaoSocial);
            Console.WriteLine(pessoa.Endereco);
        }

        static void ExcluirUmaPessoaJuridica()
        {
            Console.WriteLine("Digite o CNPJ da Empresa e ser excluida: ");
            string cnpj = Console.ReadLine();

            pessoaJuridicaService.Excluir(cnpj);
        }
    }
}
