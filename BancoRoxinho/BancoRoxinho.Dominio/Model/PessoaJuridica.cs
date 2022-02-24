using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    //PessoaJuritica herdando Pessoa
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
