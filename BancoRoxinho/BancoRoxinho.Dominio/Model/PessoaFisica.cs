using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoRoxinho.Dominio.Model
{
    [Table("tbl_pessoaFisica")]
    public class PessoaFisica : Pessoa
    {
        public static readonly int IdadeMinima = 18;

        [Required]
        [Column("idade")]
        public int Idade { get; set; }

        [Column("nome_da_mae")]
        public string NomeDaMae { get; set; }
 
        [Required]
        [MaxLength(15)]
        public string CPF { get; set; }

        [MaxLength(45)]
        [Column("nome")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [NotMapped]
        public string NomeCompleto { 
            get
            {
                //VitorNorton
                //Vitor Norton
                return Nome + " " + Sobrenome;
            }
        }

        [NotMapped]
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
            var verificador = new CPFCNPJ.Main();
            var cpfValido = verificador.IsValidCPFCNPJ(cpfASerValdido);
            return cpfValido;
        }


        public bool VerificarMaioridade(int idade)
        {
            return MaiorIdade;
        }
    }
}
