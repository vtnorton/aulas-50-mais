using CPFCNPJ;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {
        [Required]
        [MaxLength(18)]
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }

        public bool VerificarCNPJ(string cnpjEntrada)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjEntrada);
            // return cnpjValido;
            return true;
        }
    }
}
