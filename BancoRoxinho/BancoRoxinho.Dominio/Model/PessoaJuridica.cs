using CPFCNPJ;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {      
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

        public bool VerificarCNPJ(string cnpjSerValdido)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjSerValdido);
            return cnpjValido;
        }

    }
}
