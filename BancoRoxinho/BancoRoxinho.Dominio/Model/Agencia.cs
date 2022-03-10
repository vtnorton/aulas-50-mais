using System;
using System.ComponentModel.DataAnnotations;

namespace BancoRoxinho.Dominio.Model
{
    public class Agencia
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(45)]
        public string Nome { get; set; }

        [MaxLength(200)]
        public string Endereco { get; set; }

        public DateTime DataDeCriacao { get; set; }
    }
}
