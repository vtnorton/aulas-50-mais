using System;
using CPFCNPJ;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {
        private string cnpjaValidar;

        //[Key]
        //public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [MaxLength(18)]       
        public string CNPJ { get; set; }

        public bool VerificaCNPJ(string cnpjAValidar)
        {
            var verificadorCNPJ = new Main();
            //cnpjAValidar = cnpjAValidar.Trim('.', '/', '-' ); Não funcionou
            cnpjAValidar = cnpjAValidar.Replace(".", "");
            cnpjAValidar = cnpjAValidar.Replace("-", "");
            cnpjAValidar = cnpjAValidar.Replace("/", "");
            return verificadorCNPJ.IsValidCPFCNPJ(cnpjAValidar);
        }

        public PessoaJuridica CadastrarPessoa()
        {
            throw new NotImplementedException();
        }
    }
}
