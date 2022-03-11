using System;
using CPFCNPJ;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {

        [Required]
        public string Nome { get; set; }
        [Required]
        [MaxLength(18)]       
        public string CNPJ { get; set; }

        public bool VerificaCNPJ(string cnpjAValidar)
        {
            var verificadorCNPJ = new Main();
            cnpjAValidar = cnpjAValidar.Replace(".", "");
            cnpjAValidar = cnpjAValidar.Replace("-", "");
            cnpjAValidar = cnpjAValidar.Replace("/", "");
            return verificadorCNPJ.IsValidCPFCNPJ(cnpjAValidar);
        }

     
    }
}
