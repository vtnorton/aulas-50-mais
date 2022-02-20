using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using System;

namespace BancoRoxinho.Dominio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcao = "S";
            int escolhaDoUsuario;

            while (opcao.Equals("S"))
            {
                Console.Clear();
                Console.WriteLine("Bem vindo ao banco Roxinho");
                Console.WriteLine("Escolha um número para prosseguir:");
                Console.WriteLine("1 - Cadastrar pessoa física");
                Console.WriteLine("2 - Ler pessoas físicas cadastradas");
                Console.WriteLine("3 - Cadastrar pessoas juridicas ");
                Console.WriteLine("4 - Ler pessoas juridicas cadastradas ");

                escolhaDoUsuario = int.Parse(Console.ReadLine());
                if (escolhaDoUsuario == 1)
                {
                    EscolheuAOpcaoCadastrarPessoa();
                }

                if (escolhaDoUsuario == 2)
                {
                    EscolheuAOpcaoDeVerPessoasFisicas();
                }
                if (escolhaDoUsuario == 3)
                {
                    EscolheuAOpcaoCadastrarPessoaJuridica();
                }

                if (escolhaDoUsuario == 4)
                {
                    EscolheuAOpcaoDeVerPessoasJuridicas();
                }
                Console.WriteLine("Deseja realizar outra operação (S/N)");
                opcao = Console.ReadLine();

            }

            //Console.Read();
        }

       
        static void EscolheuAOpcaoDeVerPessoasFisicas()
        {
            var listaPessoas = PessoasRepository.PessoasFisicas;

            // Explicar melhor na próxima aula
            for (int contador = 0; contador < listaPessoas.Count; contador++)
            {
                // Explicar melhor na próxima aula
                var pessoa = listaPessoas[contador];
                Console.WriteLine("");
                Console.WriteLine("Pessoa de Nº " + contador);
                Console.WriteLine("Nome da pessoa: " + pessoa.Nome);
                Console.WriteLine("Idade da pessoa: " + pessoa.Idade);
                Console.WriteLine("Conta da pessoa: " + pessoa.CPF);
                Console.WriteLine("");
            }
        }

        static void EscolheuAOpcaoCadastrarPessoa()
        {
            var pessoa = new PessoaFisica();
            var pessoaCadastrada = pessoa.CadastrarPessoa();

            PessoasRepository.PessoasFisicas.Add(pessoaCadastrada);
        }
        private static void EscolheuAOpcaoDeVerPessoasJuridicas()
        {

            var listaPessoasJuridicas = PessoasRepository.PessoaJuridicas;

            for (int contador = 0; contador < listaPessoasJuridicas.Count; contador++)
            {
                
                var pessoaJuridica = listaPessoasJuridicas[contador];
                Console.WriteLine("");
                Console.WriteLine("Empresa de Nº " + contador);
                Console.WriteLine("Nome da empresa: " + pessoaJuridica.RazaoSocial);
                Console.WriteLine("CNPJ da pessoa: " + pessoaJuridica.CNPJ);
               
                Console.WriteLine("");
            }
        }

        private static void EscolheuAOpcaoCadastrarPessoaJuridica()
        {
            var pessoaJuridica = new PessoaJuridica();
            var pessoaJuridicaCadastrada = pessoaJuridica.CadastrarPessoaJuridica();

            PessoasRepository.PessoaJuridicas.Add(pessoaJuridicaCadastrada);

        }

    }
}
