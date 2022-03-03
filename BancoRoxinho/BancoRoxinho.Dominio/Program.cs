﻿using BancoRoxinho.Dominio.Dados;
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
                Console.WriteLine("2 - Cadastrar pessoa Jurídica");
                Console.WriteLine("3 - Ler pessoas físicas cadastradas");
                Console.WriteLine("4 - Editar uma pessoa física");
                Console.WriteLine("5 - Deletar uma pessoa física");                
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
                        EscolheuAOpcaoCadastrarPessoaJuridica();
                        break;
                    case 3:
                        EscolheuAOpcaoDeVerPessoasFisicas();
                        break;
                    case 4:
                        EscolheuAOpcaoEditarUmaPessoaFisica();
                        break;
                    case 5:
                        EscolheuAOpcaoDeExcluirPessoaFisica();
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

        static void EscolheuAOpcaoCadastrarPessoaJuridica()
        {
            PessoaJuridica pessoa = new PessoaJuridica();
            
            Console.WriteLine("Digite o nome do responsável jurídico: ");
            pessoa.NomePJ = Console.ReadLine();
        
            Console.WriteLine("Digite o seu sobrenome do responsável jurídico: ");
            pessoa.SobrenomePJ = Console.ReadLine();

            Console.WriteLine("Digite a razão social da empresa: ");
            pessoa.RazaoSocialPJ = Console.ReadLine();

            Console.WriteLine("Digite a idade do responsável jurídico: ");
            pessoa.IdadePJ = int.Parse(Console.ReadLine());            

            Console.WriteLine("Digite o CNPJ da empresa: ");
            pessoa.CNPJ = Console.ReadLine();
            
            Console.WriteLine("Digite o seu endereço da empresa: ");
            pessoa.EnderecoPJ = Console.ReadLine();

            pessoaJuridicaService.Adicionar(pessoa.NomePJ, pessoa.SobrenomePJ, pessoa.RazaoSocialPJ, pessoa.IdadePJ,  pessoa.EnderecoPJ);

        }

        
    }
}
