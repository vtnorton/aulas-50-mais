using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    //PessoaJuritica herdando Pessoa
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ = "00.000.000/0000-00";
        public string Nome;

        bool VerificarCNPJ()
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(CNPJ);
            if(!cnpjValido)
            {
                Console.WriteLine("CNPJ Inválido");
                return false;
            }
            return cnpjValido;
        }
    public PessoaJuridica CadastrarPessoaJuridica(PessoaJuridica pessoa)
        {
            var pessoaJuridica = new PessoaJuridica();

            Console.WriteLine("Digite o nome da Empresa: ");
            pessoa.Nome = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ da Empresa: " + pessoaJuridica.CNPJ + ":");
            pessoaJuridica.CNPJ = Console.ReadLine();


            bool cnpjValido = VerificarCNPJ(PessoaJuridica.CNPJ);
            if (!cnpjValido)
            {
                Console.WriteLine("CNPJ Inválido");
                return null;
            }

            return pessoa;
        }
    }
}
