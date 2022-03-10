using CPFCNPJ;
using System;
using System.ComponentModel.DataAnnotations;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {
        [Required]
        [MaxLength(15)]
        public string CNPJ { get; set; }

        [Required]
        [MaxLength(45)]
        public string RazaoSocial { get; set; }


        public bool VerificarCNPJ(string cnpjASerValido)
        {
            var verificador = new Main();
            string cnpjCorrigido = cnpjASerValido;

            if (!string.IsNullOrWhiteSpace(cnpjCorrigido) && !string.IsNullOrEmpty(cnpjCorrigido)) {
                cnpjCorrigido = cnpjASerValido.Trim();
                cnpjCorrigido = cnpjASerValido.Replace(".", "");
                cnpjCorrigido = cnpjASerValido.Replace("/", "");
                cnpjCorrigido = cnpjASerValido.Replace("-", "");
            }

            var cnpjValido = verificador.IsValidCPFCNPJ(cnpjCorrigido);
            return cnpjValido;
        }
    }
}
