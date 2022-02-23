using System;
using CPFCNPJ;
using BancoRoxinho.Dominio.Dados;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ = "";
        public string Nome;

        bool VerificarCNPJ(string cnpjASerValidado)
        {
            var verificadorCNPJ = new Main();
            return verificadorCNPJ.IsValidCPFCNPJ(cnpjASerValidado);
            
        }

        bool CNPJJaFoiCadastrado(string cnpjASerValidado)
        {
            var listaPJs = PessoasRepository.PessoaJuridicas;
            foreach (var pj in listaPJs)
            {
                if (pj.CNPJ == cnpjASerValidado)
                {
                    return true;
                }
            }

            return false;
        }

        public PessoaJuridica CadastrarPessoa()
        {
            var pessoa = new PessoaJuridica();
            Console.WriteLine("Digite o nome da empresa: ");
            pessoa.Nome = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ de " + pessoa.Nome + ":");
            pessoa.CNPJ = Console.ReadLine();

            bool cnpjValido = VerificarCNPJ(pessoa.CNPJ);
            if (!cnpjValido)
            {
                Console.WriteLine("\nCNPJ inválido.\n");
                return null;
            }

            if (CNPJJaFoiCadastrado(pessoa.CNPJ))
            {
                Console.WriteLine("\nCNPJ já cadastrado\n");
                return null;
            }
            
            Console.Clear();

            return pessoa;
        }
    }
}
