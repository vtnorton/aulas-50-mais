using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{

    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ = "00.000.000/0000-00";
        public string Nome;

        public bool VerificarCPF(string cnpjASerValdido)
        {
            var verificador = new Main();//nome dado pelo criador do pacote
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValdido); //o dev criou esse metodo dentro do objeto
            return cnpjValido;
        }
        public PessoaJuridica CadastrarPessoa()
        {

            var pessoa = new PessoaJuridica();
            Console.WriteLine("Digite a Razão Social da empresa");
            pessoa.Nome = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ de " + pessoa.Nome + ";");
            pessoa.CNPJ = Console.ReadLine();

            if (!VerificarCPF(pessoa.CNPJ))
            {
                Console.WriteLine("CNPJ inválido!");
                return null;
            }

            return pessoa;
        }
    }
}
