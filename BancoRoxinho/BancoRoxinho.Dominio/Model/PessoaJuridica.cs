using CPFCNPJ;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoRoxinho.Dominio.Model
{
    public class PessoaJuridica : Pessoa
    {
            public string CNPJ { get; set; }

            [Required]
            public string RazaoSocial { get; set; }

            public string NomeFanstasia { get; set; }

            [NotMapped]
            public string Nome
            {
                get
                {
                    if (string.IsNullOrWhiteSpace(NomeFanstasia))
                        return RazaoSocial;

                    return NomeFanstasia;
                }
            }

            public bool VerificarCNPJ(string cnpj)
            {
            cnpj = cnpj.Trim('/', '.', '-');

                return true;
            }
    }
}
