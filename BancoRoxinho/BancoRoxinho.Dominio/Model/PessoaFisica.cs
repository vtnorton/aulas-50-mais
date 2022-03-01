using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaFisica : Pessoa
    {
        public static readonly int IdadeMinima = 18;

        public int Idade { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string NomeCompleto { 
            get
            {
                //VitorNorton
                //Vitor Norton
                return Nome + " " + Sobrenome;
            }
        }

        public bool MaiorIdade {
            get
            {
                if (Idade >= IdadeMinima)
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
            var verificador = new Main();//nome dado pelo criador do pacote
            var cpfValido = verificador.IsValidCPFCNPJ(cpfASerValdido); //o dev criou esse metodo dentro do objeto
            return cpfValido;
        }

        public bool VerificarMaioridade(int idade)
        {
            return MaiorIdade;
        }
    }
}
