using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using BancoRoxinho.Dominio.Service;
using System;
using System.Collections.Generic;


namespace BancoRoxinho.Dominio
{
    internal class Program
    {
        private static PessoaFisicaService pessoaFisicaService = new PessoaFisicaService();

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
                Console.WriteLine("4 - Excluir uma pessoa física");
                Console.WriteLine("5 - Cadastrar pessoa jurídica");
                Console.WriteLine("6 - Ler pessoas juridica cadastrada");
                Console.WriteLine("7 - Editar pessoa juridica cadastrada");
                Console.WriteLine("8 - Excluir pessoa juridica cadastrada");
                Console.WriteLine("0 - Sair");

                int escolhaDoUsuario = int.Parse(Console.ReadLine());

                // switch case
                // mudar  caso

                switch (escolhaDoUsuario)
                {
                    case 1:
                        EscolheuAOpcaoCadastrarPessoaFisica();
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
                        EscolheuOpcaoCadastrarPessoaJuridica();
                        break;
                    case 6:
                        EscolheuOpcaoVerPessoasJuridica(); 
                        break;
                    case 7:
                        EscolheuOpcaoEditarPessoaJuridica();
                        break;
                    case 8:
                        EscolheuOpcaoExcluirPessoaJuridica();
                        break;                        
                    case 0:
                    default: //padrão
                        continuarNoPrograma = false;
                        break;
                }
            } while (continuarNoPrograma);
        }

        static void EscolheuOpcaoCadastrarPessoaJuridica()
        {
            PessoaJuridica pessoaJuridicaService = new PessoaJuridica();

            Console.WriteLine("Digite a Razão Social da Empresa: ");
            pessoaJuridicaService.RazaoSocial = Console.ReadLine();

            Console.WriteLine("Digite apenas os números do CNPJ da Empresa: ");
            pessoaJuridicaService.CNPJ = Console.ReadLine();

            Console.WriteLine("Digite o endereço da Empresa: ");
            pessoaJuridicaService.Endereco = Console.ReadLine();

            PessoaJuridicaService.Adicionar(cnpj, endereco, razaosocial); 

        }
        
        static void EscolheuOpcaoVerPessoasJuridica()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("==== EXIBINDO PESSOAS JURÍDICAS CADASTRADAS ====");
            List<PessoaJuridica> listaDePessoasJuridicas = PessoasRepository.PessoaJuridicas;

            foreach (PessoaJuridica pessoaJuridica in listaDePessoasJuridicas)
            {
                Console.WriteLine("\n" + pessoaJuridica.RazaoSocial);
                Console.WriteLine("Nº da Conta: " + pessoaJuridica.ContaCorrente.NumeroDaConta);
                if (!string.IsNullOrEmpty(pessoaJuridica.Endereco))
                {
                    Console.WriteLine("Endereço: " + pessoaJuridica.Endereco);
                }
                Console.WriteLine("CNPJ nº: " + pessoaJuridica.CNPJ);
            }
            Console.ResetColor();
        }

        static void EscolheuOpcaoEditarPessoaJuridica()
        {
            Console.WriteLine("Digite apenas os números do CNPJ desejado: ");
            string cnpj = Console.ReadLine();

            var pessoaJuridicaEditada = PessoaJuridicaService.obterPessoaJuridica(cnpj);

            Console.WriteLine("Pressione ENTER para pular uma etapa.");

            Console.WriteLine("Digite o nome da razão social: (Nome atual: " + pessoaJuridicaEditada.RazaoSocial + ")");
            pessoaJuridicaEditada.RazaoSocial = Console.ReadLine();


            Console.WriteLine("Digite apenas os números do CNPJ a ser editado: (Nome atual: " + pessoaJuridicaEditada.CNPJ + ")");
            pessoaJuridicaEditada.CNPJ = Console.ReadLine();


            Console.WriteLine("Digite o seu endereço:  (Endereço atual: " + pessoaJuridicaEditada.Endereco + ")");
            pessoaJuridicaEditada.Endereco = Console.ReadLine();

            pessoaFisicaService.Editar(
                pessoaJuridicaEditada.CNPJ,
                pessoaJuridicaEditada.RazaoSocial,
                pessoaJuridicaEditada.Endereco);
        }

        static void EscolheuOpcaoExcluirPessoaJuridica()
        {
            Console.WriteLine("Digite apenas os números do CNPJ da empresa a ser excluida: ");
            string cnpj = Console.ReadLine();

            pessoaFisicaService.Excluir(cnpj);

        }

        static void EscolheuAOpcaoDeVerPessoasFisicas()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("==== EXIBINDO PESSOAS FÍSICAS CADASTRADAS ====");
            List<PessoaFisica> listaDePessoas = PessoasRepository.PessoasFisicas;
            
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

        static void EscolheuAOpcaoCadastrarPessoaFisica()  
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

            pessoaFisicaService.Adicionar(pessoa.Nome, pessoa.Sobrenome, pessoa.Idade, pessoa.CPF, pessoa.Endereco);
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
    }
}
