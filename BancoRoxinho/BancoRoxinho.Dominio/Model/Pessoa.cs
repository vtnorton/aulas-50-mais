using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoRoxinho.Dominio.Model
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        public string Endereco { get; set; }
        public ContaCorrente ContaCorrente { get; set; }

        public Pessoa()
        {
            ContaCorrente = new ContaCorrente();
        }
    }
}
