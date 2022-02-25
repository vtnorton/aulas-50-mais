using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
<<<<<<< HEAD
    //PessoaJuritica herdando Pessoa
=======
    // Pessoa Juridica herda Pessoa
>>>>>>> a0ae49a8e7eb863540cc24ea553552ebb6e6fae2
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ = "00.000.000/0000-00";
        public string Nome;

        public bool VerificarCNPJ(string cnpjASerValidado)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValidado);
            if (!cnpjValido)
            {
                Console.WriteLine("CNPJ Inválido");
                return false;
            }
            return cnpjValido;
        }
        public PessoaJuridica CadastrarPessoaJuridica()
        {
            var pessoaJuridica = new PessoaJuridica();

            Console.WriteLine("Digite o nome da Empresa: ");
            pessoaJuridica.Nome = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ da Empresa: " + pessoaJuridica.Nome + ":");
            pessoaJuridica.CNPJ = Console.ReadLine();


            bool cnpjValido = VerificarCNPJ(pessoaJuridica.CNPJ);
            if (!cnpjValido)
            {
                return null;
            }

            return pessoaJuridica;
        }
    }
}
