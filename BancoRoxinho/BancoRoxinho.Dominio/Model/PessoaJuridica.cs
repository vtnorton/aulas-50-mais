using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {
        public static readonly int IdadeMinima = 18;

        public int IdadePJ { get; set; }
        public string NomePJ { get; set; }
        public string SobrenomePJ { get; set; }
        public string RazaoSocialPJ { get; set; }                
        public string CNPJ { get; set; }
        public string EnderecoPJ { get; set; }

        public string RazaoSocial {
            get
            {
                //VitorNorton
                //Vitor Norton
                return NomePJ + " " + SobrenomePJ;
            }
        }

        public bool MaiorIdade
        {
            get
            {
                if (IdadePJ >= IdadeMinima)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    public bool VerificarCNPJ(string cnpjSerValdido)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjSerValdido);
            return cnpjValido;
        }

        public bool VerificarMaioridade(int idade)
        {
            return MaiorIdade;
        }
    }
}
