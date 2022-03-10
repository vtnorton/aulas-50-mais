using BancoRoxinho.Dominio.Model;
using BancoRoxinho.Dominio.Services;
using System;
using System.Collections.Generic;



namespace BancoRoxinho.Dominio.Controlador
{
    internal class ControlaAcessoPessoaJuridica
    {

        public void AcessouPessoaJuridica()
        {
            bool ContinuarNoPrograma = true;

            do
            {
                Console.WriteLine("Bem vindo ao banco Roxinho");
                Console.WriteLine("Escolha um número para prosseguir:");
                Console.WriteLine("1 - Cadastrar pessoa física");
                Console.WriteLine("2 - Ler uma pessoa física cadastrada");
                Console.WriteLine("3 - Ler uma lista de pessoas físicas cadastradas");
                Console.WriteLine("4 - Editar uma pessoa física cadastrada");
                Console.WriteLine("5 - Excluir uma pessoa física cadastrada");
                Console.WriteLine("0 - Sair");

                int escolhaDoUsuario = int.Parse(Console.ReadLine());

                // switch case
                // mudar  caso

                switch (escolhaDoUsuario)
                {
                    case 1:
                        AcessarCadastrarPessoaJuridica();
                        break;
                    case 2:
                        AcessarObterUmaPessoaJuridica();
                        break;
                    case 3:
                        AcessarObterUmaListaDePessoaJuridica();
                        break;
                    case 4:
                        AcessarEditarUmaPessoaJuridica();
                        break;
                    case 5:
                        AcessarExcluirUmaPessoaJuridica();
                        break;
                    case 0:
                    default: 
                        ContinuarNoPrograma = false;
                        break;
                }

            } while (ContinuarNoPrograma);
        }

        static void AcessarCadastrarPessoaJuridica()
        {

        }

        static void AcessarObterUmaPessoaJuridica()
        {

        }

        static void AcessarObterUmaListaDePessoaJuridica()
        {

        }

        static void AcessarEditarUmaPessoaJuridica()
        {

        }

        static void AcessarExcluirUmaPessoaJuridica()
        {

        }
    }
}


       /* bool continuarNoPrograma = true;           

            do
            {
                
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

            Console.WriteLine("Digite o CNPJ da empresa: ");
            pessoa.CNPJ = Console.ReadLine();

            Console.WriteLine("Digite o seu endereço da empresa: ");
            pessoa.EnderecoPJ = Console.ReadLine();

            PessoaJuridicaService.Adicionar(pessoa.NomePJ, pessoa.SobrenomePJ, pessoa.RazaoSocialPJ, pessoa.CNPJ, pessoa.EnderecoPJ);
        }

        static void EscolheuAOpcaoDeVerPessoasFisicas()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("==== EXIBINDO PESSOAS FÍSICAS CADASTRADAS ====");
            List<PessoaFisica> listaDePessoas = pessoaFisicaService.ObterLista();

            foreach (PessoaFisica pessoa in listaDePessoas)
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
    }
}

