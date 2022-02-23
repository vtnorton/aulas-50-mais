using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ = "57832188000151";
        public string Razao = "";

        private bool VerificarCNPJ(string cnpjASerValidado)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValidado);
            return cnpjValido;
        }
        public PessoaJuridica CadastrarPessoaJuridica()
        {
            var pessoaJuridica = new PessoaJuridica();

            Console.WriteLine("Digite o nome da Empresa: ");
            pessoaJuridica.Razao = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ da Empresa: " + pessoaJuridica.CNPJ + ":");
            pessoaJuridica.CNPJ = Console.ReadLine();

           
            bool cnpjValido = VerificarCNPJ(pessoaJuridica.CNPJ);
            if (!cnpjValido)
            {
                Console.WriteLine("CNPJ Inválido");
                return null;
            }
           
            return pessoaJuridica; 
        }
    }
}
