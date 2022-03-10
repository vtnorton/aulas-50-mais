using CPFCNPJ;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaJuridica : Pessoa
    {
        [Key]
        public new int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }

        public bool VerificarCNPJ(string cnpjASerValdido)
        {
            var verificador = new Main();
            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValdido);
            return cnpjValido;
        }
    }
}

/*
 * public bool VerificarCNPJ()
 * {
 *      string cnpj = "73.410.013/0001-02";
 *      cnpj = cnpj.Trim(".", "-", "/",);
 *             
 *      return true;
 */