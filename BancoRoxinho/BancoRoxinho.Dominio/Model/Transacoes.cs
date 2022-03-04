using System.ComponentModel.DataAnnotations;

namespace BancoRoxinho.Dominio.Model
{
    public class Transacoes
    {
        [Key]
        public int Id { get; set; }
        public float Valor { get; set; }
        public string Descricao { get; set; }
        public ContaCorrente ContaOrigem { get; set; }
        public ContaCorrente ContaDestino { get; set; }
    }
}