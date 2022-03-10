using BancoRoxinho.Dominio.Controlador;
using System;


namespace BancoRoxinho.Dominio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool ContinuarNoPrograma = true;

            do
            {
                Console.WriteLine("Bem vindo ao banco Roxinho");
                Console.WriteLine("Escolha um número para prosseguir:");
                Console.WriteLine("1 - Cadastrar pessoa física");
                Console.WriteLine("2 - Ler uma pessoa física cadastrada");
                Console.WriteLine("3 - Sair");

                int escolhaDoUsuario = int.Parse(Console.ReadLine());

                // switch case
                // mudar  caso

                switch (escolhaDoUsuario)
                {
                    case 1:
                        EscolheuPessoaFisica();
                        break;
                    case 2:
                        EscolheuPessoaJuridica();
                        break;
                    case 0:
                    default:
                        ContinuarNoPrograma = false;
                        break;
                }

            } while (ContinuarNoPrograma);
        }

        public EscolheuPessoaFisica()
        {
            ControlaAcessoPessoaFisica Acesso = new ControlaAcessoPessoaFisica();  
            var acessou = Acesso.


        }

        static void EscolheuPessoaJuridica()
        {

        }
    }
}