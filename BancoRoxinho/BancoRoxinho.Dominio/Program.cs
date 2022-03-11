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
            // do while
            // faça enquanto
            bool continuarNoPrograma = true;
            do
            {
                Console.WriteLine("Bem vindo ao banco Roxinho");
                Console.WriteLine("Escolha um número para prosseguir:");
                Console.WriteLine("1 - Cadastrar pessoa física");
                Console.WriteLine("2 - Ler pessoas físicas cadastradas");
                Console.WriteLine("3 - Editar uma pessoa física");
                Console.WriteLine("4 - Deletar uma pessoa física");
                Console.WriteLine("5 - Visualizar uma pessoa física");
                Console.WriteLine("6 - Cadastrar uma pessoa juridica");
                Console.WriteLine("7 - Visualizar pessoas juridicas");
                Console.WriteLine("8 - Excluir pessoa juridica");


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
                        EscolheuAOpcaoEditarUmaPessoaFisica();
                        break;
                    case 4:
                        EscolheuAOpcaoDeExcluirPessoaFisica();
                        break;
                    case 5:
                        EscolheuAOpcaoDeVisualizarPessoaFisica();
                        break;
                    case 6:
                        EscolheuAOpcaoDeCadastrarPessoaJuridica();
                        break;
                    case 7:
                        EscolheuAOpcaoDeVisualizarPessoaJuridica();
                        break;
                    case 8:
                        EscolheuAOpcaoDeExcluirPessoaJuridica();
                        break;
                    case 0:
                    default: //padrão
                        continuarNoPrograma = false;
                        break;
                }

            } while (continuarNoPrograma);
        }

        static void EscolheuAOpcaoDeCadastrarPessoaJuridica()
        {
            PessoaJuridica pessoa = new PessoaJuridica();
            
            Console.WriteLine("Digite o CNPJ: ");
            pessoa.CPNJ = Console.ReadLine();
            Console.WriteLine("Digite a razao social: ");
            pessoa.RazaoSocial = Console.ReadLine();
            Console.WriteLine("Digite o nome fantasia: ");
            pessoa.NomeFantasia = Console.ReadLine();
            Console.WriteLine("Digite o endereco: ");
            pessoa.Endereco = Console.ReadLine();

            pessoaJuridicaService.Cadastrar(pessoa);
        }
        static void EscolheuAOpcaoDeVerPessoasFisicas()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
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
        static void EscolheuAOpcaoDeExcluirPessoaJuridica()
        {
            Console.WriteLine("Digite o CNPJ da empreas a ser excluída: ");
            var cnpj = Console.ReadLine();
            pessoaJuridicaService.ExcluirPJ(cnpj);

        }

        static void EscolheuAOpcaoCadastrarPessoa()
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


            // pessoaFisicaService.Adicionar(pessoa.Nome, pessoa.Sobrenome, pessoa.Idade, pessoa.CPF, pessoa.Endereco);

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
            Console.WriteLine("Digite o CPF da pessoa a ser excluida: ");
            string cpf = Console.ReadLine();

            pessoaFisicaService.Excluir(cpf); 
        }
        
        static void EscolheuAOpcaoDeVisualizarPessoaFisica()
        {
            Console.WriteLine("Digite o CPF da pessoa que quer visualizar: ");
            string cpf = Console.ReadLine();

            var pessoa = pessoaFisicaService.ObterPessoa(cpf);

            Console.WriteLine(pessoa.NomeCompleto);
            Console.WriteLine(pessoa.Idade);
            Console.WriteLine(pessoa.Endereco);
        }

        static void EscolheuAOpcaoDeVisualizarPessoaJuridica()
        {
            var pessoa = new PessoaJuridicaService();
            var listaCompleta = pessoa.ObterLista();
            
            foreach (var  item in listaCompleta)
            {
                Console.WriteLine(item.RazaoSocial);
                Console.WriteLine(item.NomeFantasia);
                Console.WriteLine(item.CPNJ);
                Console.WriteLine(item.Id);


                Console.WriteLine("Digite Enter");
                Console.ReadLine();
            }


        }
    }
}
