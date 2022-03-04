using System;
using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaFisica : Pessoa
    {
        public int Idade { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public static readonly int IdadeMinima = 18;

        public string NomeCompleto
        {
            get
            {
                return Nome + " " + Sobrenome;
            }
        }

        public bool MaiorIdade
        {
            get
            {
                if (Idade >= 18)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool VerificarCPF(string cpfASerValdido)
        {
            var verificador = new Main();
            var cpfValido = verificador.IsValidCPFCNPJ(cpfASerValdido);
            return cpfValido;
        }

        public bool VerificarMaioridade(int idade)
        {
            return MaiorIdade;
        }
 
    }
}