using CPFCNPJ;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {       
        public static readonly int IdadeMinimaPJ = 18;

        [Key]
        public new int Id { get; set; }
        public int IdadePJ { get; set; }
        public string NomeDaMaePJ { get; set; }

        [Required]
        [MaxLength(15)]
        public string CNPJ { get; set; }
        public string NomePJ { get; set; }
        public string SobrenomePJ { get; set; }

        [NotMapped]
        public string NomeCompletoPJ
        {
            get
            {                
                return NomePJ + " " + SobrenomePJ;
            }
        }

        [NotMapped]
        public bool MaiorIdadePJ
        {
            get
            {
                if (IdadePJ >= IdadeMinimaPJ)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string RazaoSocialPJ { get; internal set; }
        public string EnderecoPJ { get; internal set; }

        public bool VerificarCNPJ(string cnpjASerValdido)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValdido);
            return cnpjValido;
        }

        public bool VerificarMaioridade(int idade)
        {
            return MaiorIdadePJ;
        }
    }
}
